using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using AccountBalance.Application.Events;
using AccountBalance.Application.Commands;
using AccountBalance.Domain.ServiceRepos;
using static AccountBalance.Application.Common.Event;
using AccountBalance.Application.Common;

namespace AccountBalance.Domain.Aggregates.AccountAggregate
{
    public class Account : AggregateRoot
    {
        //private List<Operation> _operations;
        //public IEnumerable<Operation> Operations => _operations.AsReadOnly();

        private string _accountName;
        private decimal _funds;
        private AccountState _state;
        private decimal _wireTransferLimit;
        private decimal _overDraftLimit;

        public Account(string accountName, decimal wireTransferLimit, decimal overDraftLimit)
        {
            _state = AccountState.UNBLOCKED;
            _accountName = !string.IsNullOrWhiteSpace(accountName) ? accountName : throw new ArgumentNullException(nameof(accountName));
            _wireTransferLimit = (wireTransferLimit >= 0) ? wireTransferLimit : throw new Exception("Wire transfer limit can't be a negative value");
            _overDraftLimit = (overDraftLimit >= 0) ? overDraftLimit : throw new Exception("Overdraft limit can't be a negative value");
        }

        private void Apply(DepositSuccededEvent evt)
        {
            _funds += evt.Amount;
        }

        private void Apply(WithdrawSuccededEvent evt)
        {
            _funds -= evt.Amount;
        }

        private void Apply(UnblockAccountCommand evt)
        {
            _state = AccountState.UNBLOCKED;
        }
        private void Apply(BlockAccountCommand evt)
        {
            _state = AccountState.BLOCKED;
        }

        private void BlockAccount()
        {
            var evt = new BlockAccountCommand(guid.ToString());
            Append(evt);
            Apply(evt);
        }

        public void Deposit(decimal amount)
        {
            if (amount < 0)
            {
                throw new InvalidOperationException("Invalid amount value");
            }

            var depositSucceded = new DepositSuccededEvent(guid.ToString(), amount, EventReasons.NONE);
            Append(depositSucceded);
            Apply(depositSucceded);

            if (_state.Equals(AccountState.BLOCKED))
            {
                var unblockAccountEvent = new UnblockAccountCommand(guid.ToString());
                Append(unblockAccountEvent);
                Apply(unblockAccountEvent);
            }           
        }

        public void Withdraw(decimal amount)
        {
            if (_state.Equals(AccountState.BLOCKED)) throw new Exception(" This Account is blocked, you cannot withdraw funds");

            if (amount < 0) throw new InvalidOperationException("negative amount");

            if ((_funds - amount) <= -_overDraftLimit) BlockAccount();

            var WithdrawSuccededEvt = new WithdrawSuccededEvent(guid.ToString(), amount, EventReasons.NONE);
            Append(WithdrawSuccededEvt);
            Apply(WithdrawSuccededEvt);
        }
    }
}
