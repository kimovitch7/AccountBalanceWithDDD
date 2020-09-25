using AccountBalance.Application.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountBalance.Application.Handlers
{
    class WithdrawFailedHandler
    {
        public Task HandleEventAsync(AccountBlockedEvent @event)
        {
            // TODO : Add event to event store
            Console.WriteLine($"Received message '{@event.Reason}'");
            return Task.CompletedTask;
        }
    }
}
