using AccountBalance.Application.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountBalance.Application.Events
{
    public class AccountBlockedEvent : Event
    {
        public string AccountId { get; }
        public AccountBlockedEvent(string accountId) => AccountId = accountId;
    }
}
