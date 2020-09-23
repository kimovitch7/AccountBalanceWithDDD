using AccountBalance.Application.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountBalance.Application.Events
{
    public class WithdrawFailedEvent : Event
    {
        public string OperationId { get; }
        public WithdrawFailedEvent(string orderId, EventReasons reason) : base(reason) => OperationId = orderId;
    }
}
