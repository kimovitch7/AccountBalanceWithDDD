using NServiceBus;

namespace AccountBalance.Application.Common
{
    public interface IServiceRepository<T> where T : AggregateRoot
    {
        public void RegisterEvent(IMessage evt);
    }
}
