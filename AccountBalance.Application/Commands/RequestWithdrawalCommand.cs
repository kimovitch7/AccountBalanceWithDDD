using System;
using System.Collections.Generic;
using System.Text;

namespace AccountBalance.Application.Commands
{
    public class RequestWithdrawalCommand
    {
        public string AccountId { get; }
        public decimal Amount { get; }
        public RequestWithdrawalCommand(string accountId, decimal amount)
        {
            AccountId = accountId;
            Amount = amount;
        }

    }
}
