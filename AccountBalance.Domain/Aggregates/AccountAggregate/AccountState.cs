using System;
using System.Collections.Generic;
using System.Text;

namespace AccountBalance.Domain.Aggregates.AccountAggregate
{
    public enum AccountState
    { 
        BLOCKED, 
        UNBLOCKED 
    }
}
