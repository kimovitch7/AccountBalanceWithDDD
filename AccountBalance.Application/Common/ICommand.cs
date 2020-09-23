using NServiceBus;
using System;
using System.Collections.Generic;
using System.Text;

namespace AccountBalance.Application.Common
{
    interface ICommand: IMessage
    {
    }
}
