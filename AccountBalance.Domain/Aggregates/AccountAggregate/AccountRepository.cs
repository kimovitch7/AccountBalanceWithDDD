using AccountBalance.Application.Common;
using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountBalance.Domain.Aggregates.AccountAggregate
{
    class AccountRepository : IServiceRepository<Account>
    {
        private List<IMessage> _domainEvents;

        public void RegisterEvent(IMessage evt)
        {
            _domainEvents.Add(evt);
        }
    }
}
