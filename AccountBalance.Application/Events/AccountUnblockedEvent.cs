using AccountBalance.Application.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountBalance.Application.Events
{
    class AccountUnblockedEvent : Event
    {
        public string AccountId { get; }

        public AccountUnblockedEvent(string accountId) => AccountId = accountId;
    }
}
