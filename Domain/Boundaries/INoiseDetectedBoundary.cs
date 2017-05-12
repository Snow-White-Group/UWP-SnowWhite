using System.Threading.Tasks;
using Domain.Entities;

namespace Domain.Boundaries
{
    internal interface INoiseDetectedBoundary
    {
        Task<IVoiceFile> DeliverNoiseFile();
    }
}