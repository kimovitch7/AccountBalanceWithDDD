using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountBalance.Application.Common
{
    public class AggregateRoot : Entity
    {
        //private
        public IServiceRepository<AggregateRoot> _serviceRepo;
        public void Append(IMessage message)
        {
            _serviceRepo.RegisterEvent(message);
        }

        protected virtual void Apply(IEvent evt)
        {

        }
    }
}
