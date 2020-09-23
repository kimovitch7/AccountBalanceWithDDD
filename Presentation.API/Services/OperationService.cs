using AccountBalance.Application.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AccountBalance.API.Services
{
    public class OperationService
    {
        public void WithdrawFromAccount(string accountGuid, int amount)
        {
            var Command = new RequestWithdrawalCommand(accountGuid, amount);
        }

        public void DepositToAccount(string accountGuid, int amount)
        {

        }
    }
}
