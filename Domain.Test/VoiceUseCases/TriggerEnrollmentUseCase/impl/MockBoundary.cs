using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Boundaries;

namespace Domain.Test.VoiceUseCases.TriggerEnrollmentUseCase.impl
{
    class MockBoundary : IDeliveryBoundary
    {
        public bool HasBeenCalled { get; set; }

        public MockBoundary()
        {
            HasBeenCalled = false;
        }
        public Task<bool> DeliverEnrollmentPage()
        {
            HasBeenCalled = true;
            return Task<bool>.Factory.StartNew(() =>
            {
                return true;
            });

        }
    }
}
