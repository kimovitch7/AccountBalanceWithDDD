using System;
using System.Collections.Generic;
using System.Text;

namespace AccountBalance.Application.Common
{
    public class Entity
    {
        private Guid _guid;

        public Guid guid
        {
            get
            {
                if (guid == null)
                    _guid = Guid.NewGuid();
                return _guid;
            }
        }
    }
}
