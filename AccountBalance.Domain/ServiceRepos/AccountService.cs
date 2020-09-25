using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AccountBalance.Application.Commands;
using AccountBalance.Domain.Aggregates.AccountAggregate;
using System.Linq;
using AccountBalance.Application.Common;
using Microsoft.Extensions.DependencyInjection;
using NServiceBus;

namespace AccountBalance.Domain.ServiceRepos
{
    public class AccountService : IDomainService<Account>, 
        IHandleMessages<RequestWithdrawalCommand>,
        IHandleMessages<RequestDepositCommand>
    {
        private IMessageSession _messageSession;
        private readonly IEnumerable<Account> _accounts;

        public AccountService(IMessageSession messageSession)
        {
            _messageSession = messageSession;
            _accounts = new List<Account>();
        }

        public Account GetById(string id)
        {
            return _accounts.Where(acct => acct.guid.ToString().Equals(id)).First();
        }

        public Task Handle(RequestDepositCommand message, IMessageHandlerContext context)
        {
            try 
            {
                var account = GetById(message.AccountId);
                account.Deposit(message.Amount);

                _messageSession.Send(message).ConfigureAwait(false);

                Task reply = context.Reply("RequestDepositCommand");
                return reply;
            }
            catch (Exception)
            {
                return context.Reply("invalid operation");
            }
        }

        public Task Handle(RequestWithdrawalCommand message, IMessageHandlerContext context)
        {
            try
            {
                var account = GetById(message.AccountId);
                account.Withdraw(message.Amount);

                _messageSession.Send(message).ConfigureAwait(false);

                Task reply = context.Reply("RequestWithdrawalCommand");
                return reply;
            }
            catch (Exception)
            {
                return context.Reply("invalid operation");
            }
        }
    }
}
