using AccountBalance.Application.Events;
using JKang.EventBus;
using System;
using System.Threading.Tasks;

namespace AccountBalance.Application.Handlers
{
    class DepositSuccededHandler : IEventHandler<DepositSuccededEvent>

    {
        public Task HandleEventAsync(DepositSuccededEvent @event)
        {
            // TODO : Add event to event store
            Console.WriteLine($"Received message '{@event.Reason}'");
            return Task.CompletedTask;
        }
    }
}
