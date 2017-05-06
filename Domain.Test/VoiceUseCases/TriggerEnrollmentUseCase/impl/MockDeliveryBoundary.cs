using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Boundaries;

namespace Domain.Test.VoiceUseCases.TriggerEnrollmentUseCase.Impl
{
    class MockDeliveryBoundary : IDeliveryBoundary
    {
        public bool HasBeenCalled { get; set; }

        public MockDeliveryBoundary()
        {
            HasBeenCalled = false;
        }
        public Task<bool> DeliverEnrollmentPage()
        {
            HasBeenCalled = true;
            return Task<bool>.Factory.StartNew(() => true);

        }

        public Task<bool> DeliverDefaultUserPage()
        {
            HasBeenCalled = true;
            return Task<bool>.Factory.StartNew(() => true);
        }
    }
}
