using AccountBalance.Application.Events;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AccountBalance.Application.Handlers
{
    public class WithdrawalSuccededHandler : IEventHandler<WithdrawSuccededEvent>
    {
        public Task HandleEventAsync(WithdrawSuccededEvent @event)
        {
            // TODO : Add event to event store
            Console.WriteLine($"Received message '{@event.Reason}'");
            return Task.CompletedTask;
        }
    }
}
