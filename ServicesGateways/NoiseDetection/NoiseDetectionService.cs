using System;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using Windows.ApplicationModel.Background;
using Windows.Devices.Enumeration;
using Windows.Media;
using Windows.Media.Audio;
using Windows.Media.Capture;
using Windows.Media.Devices;
using Windows.Media.MediaProperties;
using Windows.Storage;
using Domain.Services;
using Domain.VoiceUseCases.NoiseDetectedUseCase;

namespace ServicesGateways.NoiseDetection
{
    public class NoiseDetectionService : INoiseDetectionService
    {
        //#region unsafe Interface
        //[ComImport]
        //[Guid("5b0d3235-4dba-4d44-865e-8f1d0e4fd04d")]
        //[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
        //unsafe interface IMemoryBufferByteAccess
        //{
        //    void GetBuffer(out byte* buffer, out uint capacity);
        //}
        //#endregion

        #region audiograph
        private AudioGraph _audioGraph;
        private AudioDeviceInputNode _deviceInputNode;
        private AudioFrameOutputNode _frameOutputNode;
        private AudioFileOutputNode _fileOutputNode;
        #endregion

        #region helper
        private int _count;
        private bool _isRecoding;
        private readonly SilenceDetector _detector;
        private readonly StorageFolder _storageFolder;
        private StorageFile _mainFile;
        private BackgroundTaskDeferral _deferral;
        private readonly RingBuffer<double> _lastRecoring;
        #endregion

        #region constant
        // One sample is 10ms so 1000 samples are 10.000ms
        private const int FiveSecounds = 500;
        //if ofer the last 7 secounds there was sound keep recording
        private const int BufferTol = 250;
        // One sample is 10ms so 6000 samples are 60.000ms
        private const int OneMinute = 6000;
        #endregion

        #region Domain
        private readonly INoiseDetectedUseCase _interacor;
        #endregion

        public NoiseDetectionService(INoiseDetectedUseCase interactor)
        {
            this._interacor = interactor;
            this._detector = new SilenceDetector();
            this._isRecoding = false;
            this._storageFolder = Windows.Storage.ApplicationData.Current.LocalFolder;
            this._count = 0;
            this._lastRecoring = new RingBuffer<double>(FiveSecounds);
            InitGraph();
           
        }

        public async void Run(IBackgroundTaskInstance taskInstance)
        {
            _deferral = taskInstance.GetDeferral();
            await InitGraph();
            _deferral.Complete();
        }

        #region logic
        private async Task InitGraph()
        {
            //init the graph
            var settings = new AudioGraphSettings(Windows.Media.Render.AudioRenderCategory.Media);

            var result = await AudioGraph.CreateAsync(settings);
            if (result.Status != AudioGraphCreationStatus.Success)
            {
                Debug.WriteLine("AudioGraph creation error: " + result.Status.ToString());
            }

            _audioGraph = result.Graph;

            //create all Nodes!
            await CreateFileOutputNode();
            CreateFrameOutputNode();
            await CreateDeviceInputNode();

            ConnectNodes();
            _audioGraph.Start();
        }

        #region FrameOutPutNode
        private void CreateFrameOutputNode()
        {
            _frameOutputNode = _audioGraph.CreateFrameOutputNode();
            _audioGraph.QuantumStarted += AudioGraph_QuantumStarted;
        }

        private void AudioGraph_QuantumStarted(AudioGraph sender, object args)
        {
            var frame = _frameOutputNode.GetFrame();
            //ProcessFrameOutput(frame);
        }

        //private unsafe void ProcessFrameOutput(AudioFrame frame)
        //{
        //    using (var buffer = frame.LockBuffer(AudioBufferAccessMode.Write))
        //    using (var reference = buffer.CreateReference())
        //    {
        //        byte* dataInBytes;
        //        uint capacityInBytes;
        //        float* dataInFloat;

        //        // Get the buffer from the AudioFrame
        //        ((IMemoryBufferByteAccess)reference).GetBuffer(out dataInBytes, out capacityInBytes);

        //        //cal level
        //        dataInFloat = (float*)dataInBytes;
        //        float max = 0;
        //        for (int i = 0; i < _audioGraph.SamplesPerQuantum; i++)
        //        {
        //            max = Math.Max(Math.Abs(dataInFloat[i]), max);
        //        }

        //        ProzessEvent(_detector.Calculate(max));
        //    }
        //}
        #endregion

        private void ProzessEvent(MicrophoneInput a)
        {
            if (a.State == 1)
                Debug.WriteLine(a.Value + " : " + a.State);


            if (a.State == 1 && _isRecoding == false)
            {
                Debug.WriteLine("STARTED RECORDING!");
                _fileOutputNode.Reset();
                _fileOutputNode.Start();
                _isRecoding = true;
            }

            a.IsRecording = _isRecoding;
            _interacor.OnNoiseDetected(a);    

            if (_isRecoding)
            {
                _count++;
                _lastRecoring.Add(a.State);
            }
            //Record Noise for at least 5 secounds
            if (_count < FiveSecounds || _isRecoding != true) return;
            // if there was enough sound in this 5 secounds, keep recoring
            if (_lastRecoring.Fold((b) => b.Sum()) > BufferTol && _count < 2* FiveSecounds) return;
            _count = 0;
            _isRecoding = false;
            _fileOutputNode.Stop();

            SaveAndCleanGraph();

        }

        private void SaveAndCleanGraph()
        {
            new TaskFactory().StartNew(async () =>
            {
                var creationTask = _storageFolder.CreateFileAsync(Guid.NewGuid() + ".wav",
                    Windows.Storage.CreationCollisionOption.ReplaceExisting);
                var file = await creationTask;
                CopyFile(_mainFile, file);

                await _fileOutputNode.FinalizeAsync();
                _audioGraph.Stop();
                _audioGraph.Dispose();
                await InitGraph();
            });
        }

        private async Task CreateFileOutputNode()
        {

            Debug.WriteLine(_storageFolder.Path);
            _mainFile = await _storageFolder.CreateFileAsync("sample.wav", Windows.Storage.CreationCollisionOption.ReplaceExisting);

            var mediaEncodingProfile = MediaEncodingProfile.CreateWav(AudioEncodingQuality.High);

            // Operate node at the graph format, but save file at the specified format
            var result = await _audioGraph.CreateFileOutputNodeAsync(_mainFile, mediaEncodingProfile);

            if (result.Status != AudioFileNodeCreationStatus.Success)
            {
                // FileOutputNode creation failed
                Debug.WriteLine(result.Status.ToString());
                return;
            }

            _fileOutputNode = result.FileOutputNode;
        }

        private async Task CreateDeviceInputNode()
        {
            // Create a device output node
            var microphone = await DeviceInformation.CreateFromIdAsync(
                MediaDevice.GetDefaultAudioCaptureId(AudioDeviceRole.Default));

            var inProfile = MediaEncodingProfile.CreateWav(AudioEncodingQuality.High);

            var inputResult = await this._audioGraph.CreateDeviceInputNodeAsync(
                MediaCategory.Speech,
                inProfile.Audio,
                microphone);


            if (inputResult.Status != AudioDeviceNodeCreationStatus.Success)
            {
                // Cannot create device output node
                Debug.WriteLine(inputResult.Status.ToString());
                return;
            }

            _deviceInputNode = inputResult.DeviceInputNode;

        }

        private void ConnectNodes()
        {
            //link the Nodes together
            _deviceInputNode.AddOutgoingConnection(_fileOutputNode);
            _deviceInputNode.AddOutgoingConnection(_frameOutputNode);

            //by default we dont want to record
            _fileOutputNode.Stop();
        }


        #region I/O Helper
        public async void CopyFile(StorageFile fileToCopy, StorageFile filetoReplace)
        {
            await fileToCopy.CopyAndReplaceAsync(filetoReplace);
        }
        #endregion

        #endregion


    }
}