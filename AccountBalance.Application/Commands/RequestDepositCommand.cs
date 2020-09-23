using AccountBalance.Application.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountBalance.Application.Commands
{
    public class RequestDepositCommand : Command
    {
        public string AccountId { get; }
        public decimal Amount { get; }
        public RequestDepositCommand(string accountId, decimal amount)
        {
            AccountId = accountId;
            Amount = amount;
        }
    }
}
