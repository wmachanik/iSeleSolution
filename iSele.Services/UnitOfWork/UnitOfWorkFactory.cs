using System;
using System.Collections.Generic;
using System.Text;

namespace iSele.Services
{
   public class UnitOfWorkFactory
    {
        public IUnitOfWork Create()
        {
            return new UnitOfWork(new DatabaseContext());
        }
    }
}
