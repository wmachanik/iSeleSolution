using System;
using System.Collections.Generic;
using System.Text;

namespace iSele.Services
{
    interface IUnitOfWorkFactory
    {
        IUnitOfWork Create();
    }
}
