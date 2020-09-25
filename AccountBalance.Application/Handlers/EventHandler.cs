using AccountBalance.Application.Events;
using NServiceBus;
using System;
using System.Threading.Tasks;

namespace AccountBalance.Application.Handlers
{
    class EventHandler : IHandleMessages<DepositSuccededEvent>
        ,IHandleMessages<WithdrawSuccededEvent>
        ,IHandleMessages<AccountBlockedEvent>
        ,IHandleMessages<AccountUnblockedEvent>
    {
        public Task Handle(DepositSuccededEvent message, IMessageHandlerContext context)
        {
            throw new NotImplementedException();
        }

        public Task Handle(WithdrawSuccededEvent message, IMessageHandlerContext context)
        {
            throw new NotImplementedException();
        }

        public Task Handle(AccountBlockedEvent message, IMessageHandlerContext context)
        {
            throw new NotImplementedException();
        }

        public Task Handle(AccountUnblockedEvent message, IMessageHandlerContext context)
        {
            throw new NotImplementedException();
        }
    }
}
