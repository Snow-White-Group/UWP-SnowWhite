using Domain.Services;

namespace Domain.VoiceUseCases.NoiseDetectedUseCase
{
    public class MicrophoneInput : INoiseEvent
    {
        public static readonly int MicrostateUnkown = -1;
        public static readonly int MicrostateNoise = 1;
        public static readonly int MicrostateSilent = 0;
        public bool IsRecording { get; set; }


        public double Value { get; }
        public int State { get; }

        public MicrophoneInput(double value, int state)
        {
            this.Value = value;
            this.State = state;
            this.IsRecording = false;
        }


        public double GetCurrentLevel()
        {
            return Value;
        }

        public bool IsRecoring()
        {
            return IsRecording;
        }

        public NoiseServiceState GetCurrentState()
        {
            switch (State)
            {
                case 0:
                    return NoiseServiceState.Silent;
                case 1:
                    return NoiseServiceState.Noise;
                default:
                    return NoiseServiceState.Training;
            }
        }
    }
}