using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project_CORE.Infrastructure.Repositories;
using Final_Project_CORE.Utility;

namespace Final_Project_CORE.Infrastructure.Base
{
    public interface IUnitOfWork:IDisposable
    {

        Modelmessage Save();
        #region properties
        public ICateRepo? CateRepo { get; }

            
        #endregion
    }
}
