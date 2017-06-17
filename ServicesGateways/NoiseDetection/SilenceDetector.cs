using System;
using System.Diagnostics;
using System.Linq;
using Domain.Services;
using Domain.VoiceUseCases.NoiseDetectedUseCase;
using Microsoft.EntityFrameworkCore.Query.Expressions;

namespace ServicesGateways.NoiseDetection
{
    public class SilenceDetector 
    {
        private readonly RingBuffer<double> _baseBuffer;
        private readonly RingBuffer<double> _currentBuffer;


        public SilenceDetector()
        {
            //one minute sampling
            _baseBuffer = new RingBuffer<double>(12000);

            //one secound sampling
            _currentBuffer = new RingBuffer<double>(50);

        }


        private double SilenceTheresHold() => _baseBuffer.Fold(array => array.ToList().Average());
        private double CurrentTheresHold() => _currentBuffer.Fold(array => array.ToList().Max());

        public MicrophoneInput Calculate(double input)
        {
            if (Math.Abs(CurrentTheresHold() - SilenceTheresHold()) > 1)
            {
                return new MicrophoneInput(input, MicrophoneInput.MicrostateUnkown);
            }

            _currentBuffer.Add(input);
          
            if (!_baseBuffer.IsFull())
            {
                _baseBuffer.Add(input);
                return new MicrophoneInput(input, MicrophoneInput.MicrostateUnkown);
            }

          
            Debug.WriteLine("DIFF: " + Math.Abs(CurrentTheresHold() - SilenceTheresHold()));
            var state = Math.Abs(CurrentTheresHold() - SilenceTheresHold()) < 0.09 ? MicrophoneInput.MicrostateSilent : MicrophoneInput.MicrostateNoise;
            _baseBuffer.Add(input);
            return new MicrophoneInput(input, state);
        }

    }
}