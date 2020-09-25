using NServiceBus;
using System.Collections.Generic;

namespace AccountBalance.Application.Common
{
    public interface IDomainService<T> where T : AggregateRoot
    {
        public T GetById(string id);
    }
}
