using AccountBalance.Application.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountBalance.Application.Commands
{
    public class BlockAccountCommand : Command
    {
        public string AccountId { get; }
        public BlockAccountCommand(string accountId) => AccountId = accountId;
    }
}
