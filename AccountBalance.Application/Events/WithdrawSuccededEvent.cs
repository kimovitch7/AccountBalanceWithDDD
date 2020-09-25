using AccountBalance.Application.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountBalance.Application.Events
{
    public class WithdrawSuccededEvent : Event
    {
        public string AccountId { get; }
        public decimal Amount { get; }

        public WithdrawSuccededEvent(string accountId, decimal amount, EventReasons reason) : base(reason)
        {
            AccountId = accountId;
            Amount = amount;
        }
    }
}
