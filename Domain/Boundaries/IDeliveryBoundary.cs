namespace Domain.Boundaries
{
    using System.Threading.Tasks;

    public interface IDeliveryBoundary
    {
        Task<bool> DeliverEnrollmentPage();
    }
}