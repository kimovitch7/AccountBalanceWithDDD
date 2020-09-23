using AccountBalance.Application.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountBalance.Application.Commands
{
    public class UnblockAccountCommand : Command
    {
        public string AccountId { get; }
        public UnblockAccountCommand( string accountId) => AccountId = accountId;
    }
}
