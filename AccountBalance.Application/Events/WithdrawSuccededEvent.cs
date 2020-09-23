using AccountBalance.Application.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountBalance.Application.Events
{
    public class WithdrawSuccededEvent : Event
    {
        public string OrderId { get; }
        public string AccountId { get; }
        public decimal Amount { get; }

        public WithdrawSuccededEvent(string orderId, string accountId, decimal amount, EventReasons reason) : base(reason)
        {
            OrderId = orderId;
            AccountId = accountId;
            Amount = amount;
        }
    }
}
