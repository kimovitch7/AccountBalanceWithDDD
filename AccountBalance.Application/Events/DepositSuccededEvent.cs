using AccountBalance.Application.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountBalance.Application.Events
{
    public class DepositSuccededEvent : Event
    {
        public string AccountId { get; }    
        public decimal Amount { get; } 

        public DepositSuccededEvent(string accountId, decimal amount, EventReasons reason): base(reason)
        {
            AccountId = accountId;
            Amount = amount;
        }
    }
}
