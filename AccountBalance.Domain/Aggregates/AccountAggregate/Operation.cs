using AccountBalance.Domain.BaseClasses;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AccountBalance.Domain.Aggregates.AccountAggregate
{
    class Operation: Entity
    {
        public decimal Amount { get; private set; }
        public OperationDirection Direction { get; private set; }
        public DateTime TimeStamp { get; private set; }
        public Operation(string accountId, decimal amount, OperationDirection direction, DateTime timeStamp)
        {
            this.Amount = amount;
            this.Direction = direction;
            this.TimeStamp = timeStamp;
        }
    }
}
