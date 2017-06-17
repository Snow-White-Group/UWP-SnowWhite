namespace Domain.VoiceUseCases { 

        public interface INoiseEvent
        {
            double GetCurrentLevel();

            bool IsRecoring();

            NoiseServiceState GetCurrentState();
        }

        public enum NoiseServiceState
        {
            Training, Silent, Noise
        }
    
}