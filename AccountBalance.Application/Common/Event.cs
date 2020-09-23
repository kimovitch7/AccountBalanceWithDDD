using System;
using System.Collections.Generic;
using System.Text;

namespace AccountBalance.Application.Common
{
    public class Event: IEvent
    {
        public enum EventReasons { NONE, AMOUNT_INVALID, EXCEEDED_OVERDRAFT_LIMIT, ACCOUNT_BLOCKED }
        public EventReasons Reason { get; }
        public Event(EventReasons reason) => Reason = reason;
    }
}
