using AccountBalance.Domain.BaseClasses;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using AccountBalance.Application.Events;
using AccountBalance.Application.Commands;
using static AccountBalance.Application.Common.Event;

namespace AccountBalance.Domain.Aggregates.AccountAggregate
{
    class Account: Entity, IAggregateRoot
    {
        private List<Operation> _operations;
        public IEnumerable<Operation> Operations => _operations.AsReadOnly();
        
        public string AccountName { get; private set; }
        public decimal Funds { get; private set; }
        public AccountState State { get; private set; }
        public decimal WireTransferLimit { get; private set; }
        public decimal OverDraftLimit { get; private set; }

        public Account(string acctName, decimal fund, AccountState state, decimal wireTransferLimit, decimal overDraftLimit)
        {
            AccountName = !string.IsNullOrWhiteSpace(acctName) ? acctName : throw new ArgumentNullException(nameof(acctName));
            Funds = (fund > 0) ? fund : throw new Exception("account can't be created with a negative fund");
            State = state;
            WireTransferLimit = (wireTransferLimit >= 0) ? wireTransferLimit : throw new Exception("Wire transfer limit can't be a negative value");
            OverDraftLimit = (overDraftLimit >= 0) ? overDraftLimit : throw new Exception("Overdraft limit can't be a negative value");
            _operations = new List<Operation>();
        }

        public void Deposit(decimal amount)
        {
            var operation = new Operation(guid.ToString(), amount, OperationDirection.DEPOSIT, DateTime.Now);

            if (amount < 0)
            {
                SendDomainMessage(new WithdrawFailedEvent(guid.ToString(), EventReasons.AMOUNT_INVALID));
                return;
            }

            Funds += amount;
            _operations.Add(operation);

            SendDomainMessage(new DepositSuccededEvent(operation.guid.ToString(), guid.ToString(), amount, EventReasons.NONE));

            if (State.Equals(AccountState.BLOCKED))
            {
                State = AccountState.UNBLOCKED;
                SendDomainMessage(new BlockAccountCommand(guid.ToString()));
            }           
        }

        public void Withdraw(decimal amount)
        {
            var operation = new Operation(guid.ToString(), amount, OperationDirection.WITHDRAW, DateTime.Now);

            if (State.Equals(AccountState.BLOCKED))
            {
                SendDomainMessage(new WithdrawFailedEvent(operation.guid.ToString(), EventReasons.ACCOUNT_BLOCKED));
                return;
            }

            if (amount < 0)
            {
                SendDomainMessage(new WithdrawFailedEvent(operation.guid.ToString(), EventReasons.AMOUNT_INVALID));
                return;
            }
            
            if ((Funds - amount) <= -OverDraftLimit)
            {
                SendDomainMessage(new WithdrawFailedEvent(operation.guid.ToString(), EventReasons.EXCEEDED_OVERDRAFT_LIMIT));
                //SendDomainMessage(new BlockAccountCommand(guid.ToString())); ||| should be in the event handler of previous event
                return;
            }

            Funds -= amount;

            _operations.Add(operation);
            SendDomainMessage(new WithdrawSuccededEvent(operation.guid.ToString(), guid.ToString(), amount, EventReasons.NONE));
        }
    }
}
