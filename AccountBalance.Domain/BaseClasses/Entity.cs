using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountBalance.Domain.BaseClasses
{
    class Entity
    {
        private Guid _guid;
        public Guid guid 
        {
            get
            {
                if(guid == null)
                    _guid = Guid.NewGuid();
                return _guid;
            } 
        }

        IEndpointInstance _endpointInstance;

        public async void SendDomainMessage(IMessage message)
        {
            await _endpointInstance.Send(message)
                .ConfigureAwait(false);
        }
    }
}
