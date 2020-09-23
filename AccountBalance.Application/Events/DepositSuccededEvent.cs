using AccountBalance.Application.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountBalance.Application.Events
{
    public class DepositSuccededEvent : Event
    {
        public string OperationId { get; }
        public string AccountId { get; }    
        public decimal Amount { get; } 

        public DepositSuccededEvent(string operationId, string accountId, decimal amount, EventReasons reason): base(reason)
        {
            OperationId = operationId;
            AccountId = accountId;
            Amount = amount;
        }
    }
}
