using System;
using System.Threading.Tasks;
using AccountBalance.Application.Events;

namespace AccountBalance.Application.Handlers
{
    class DepositFailedHandler : IEventHandler<AccountUnblockedEvent>
    {
        public Task HandleEventAsync(AccountUnblockedEvent @event)
        {
            // TODO : Add event to event store
            Console.WriteLine($"Received message '{@event.Reason}'");
            return Task.CompletedTask;
        }
    }
}
