using AccountBalance.Application.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountBalance.Application.Events
{
    class DepositFailedEvent : Event
    {
        public string OperationId { get; }
        public string AccountId { get; }

        public DepositFailedEvent(string operationId, string accountId, EventReasons reason) : base(reason)
        {
            OperationId = operationId;
            AccountId = accountId;      
        }
    }
}
