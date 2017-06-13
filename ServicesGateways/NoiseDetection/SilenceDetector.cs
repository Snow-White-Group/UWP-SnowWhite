using System;
using System.Linq;
using Domain.Services;
using Domain.VoiceUseCases.NoiseDetectedUseCase;

namespace ServicesGateways.NoiseDetection
{
    public class SilenceDetector 
    {
        private readonly RingBuffer<double> _baseBuffer;
        private readonly RingBuffer<double> _currentBuffer;


        public SilenceDetector()
        {
            //one minute sampling
            _baseBuffer = new RingBuffer<double>(3 * 6000);

            //one secound sampling
            _currentBuffer = new RingBuffer<double>(50);

        }


        private double SilenceTheresHold() => _baseBuffer.CachedFold(array => array.ToList().Average(), 100);
        private double CurrentTheresHold() => _currentBuffer.Fold(array => array.ToList().Max());

        public MicrophoneInput Calculate(double input)
        {
            _currentBuffer.Add(input);

            if (!_baseBuffer.IsFull())
            {
                _baseBuffer.Add(input);
                return new MicrophoneInput(input, MicrophoneInput.MicrostateUnkown);
            }

            var state = Math.Abs(CurrentTheresHold() - SilenceTheresHold()) < 0.125 ? MicrophoneInput.MicrostateSilent : MicrophoneInput.MicrostateNoise;
            _baseBuffer.Add(input);
            return new MicrophoneInput(input, state);
        }

    }
}