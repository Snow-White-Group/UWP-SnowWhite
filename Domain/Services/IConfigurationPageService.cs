using Domain.Entities;

namespace Domain.Services
{
    public interface IConfigurationPageService
    {
        MirrorUser LoadDefaultUser();
    }
}
