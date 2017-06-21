using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Media.SpeechRecognition;
using Newtonsoft.Json;
using Domain.Entities;
using ServicesGateways;
using NAudio;
using NAudio.Wave;
using Windows.Media.Capture;
using Windows.Storage.Streams;
using Windows.Media.MediaProperties;
using Windows.Storage;
using System.Runtime.InteropServices.WindowsRuntime;
using System.IO;


namespace Snowwhite.Services
{
    public class SpeechRecognitionService
    {
        private Windows.Globalization.Language lan = new Windows.Globalization.Language("us-en");
        public SpeechRecognizer recognizer = new SpeechRecognizer();

        private CloudService webService = new CloudService();
        private InMemoryRandomAccessStream buffer = null;
        private MediaCapture capture = new MediaCapture();
        private bool record;

        public async Task IsRecordingDesired()
        {
            string id = null;

            while (id == null) {
                id = await webService.MakeRequest("http://snowwhite-configurationpage.azurewebsites.net/Account/DesireRecording");
            }

            await RecordProcess(id);
            await capture.StartRecordToStreamAsync(MediaEncodingProfile.CreateWav(AudioEncodingQuality.Auto), buffer);
            if (record)
            {
                throw new InvalidOperationException();
            }
            record = true;            
        }

        private async Task<bool> RecordProcess(string id)
        {
            if (buffer != null)
            {
                buffer.Dispose();
            }
            buffer = new InMemoryRandomAccessStream();
            if (capture != null)
            {
                capture.Dispose();
            }
            try
            {
                MediaCaptureInitializationSettings settings = new MediaCaptureInitializationSettings
                {
                    StreamingCaptureMode = StreamingCaptureMode.Audio
                };
                capture = new MediaCapture();
                
                await capture.InitializeAsync(settings);

                // This is where the byteArray to be stored.
                var bytes = new byte[buffer.Size];

                // This returns IAsyncOperationWithProgess, so you can add additional progress handling
                await buffer.ReadAsync(bytes.AsBuffer(), (uint)buffer.Size, InputStreamOptions.None);

                capture.RecordLimitationExceeded += (MediaCapture sender) =>
                {
                    //Stop
                    //   await capture.StopRecordAsync();
                    record = false;
                    throw new Exception("Record Limitation Exceeded ");
                };
                capture.Failed += (MediaCapture sender, MediaCaptureFailedEventArgs errorEventArgs) =>
                {
                    record = false;
                    throw new Exception(string.Format("Code: {0}. {1}", errorEventArgs.Code, errorEventArgs.Message));
                };

                // Create sample file; replace if exists.
                StorageFolder storageFolder =
                    await ApplicationData.Current.LocalFolder.GetFolderAsync("AudioFiles");
                StorageFile sampleFile =
                    await storageFolder.CreateFileAsync(Guid.NewGuid() + ".wav",
                        CreationCollisionOption.ReplaceExisting);

                // here this files has to be mapped to the target user or returned for the enrollments
                // maybe we don't have to save them. We just create and return the wave file

            }
            catch (Exception ex)
            {
                if (ex.InnerException != null && ex.InnerException.GetType() == typeof(UnauthorizedAccessException))
                {
                    throw ex.InnerException;
                }
                throw;
            }
            return true;
        }
    }
}
