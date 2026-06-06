using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project_CORE.Infrastructure.Base;
using Final_Project_CORE.Models;

namespace Final_Project_CORE.Infrastructure.Repositories
{
   public interface ICateRepo:IGenericRepo<Category>
    {

    }
    internal class CateRepo : GenericRepo<Category>, ICateRepo
    {
        public CateRepo(InvContext context) : base(context)
        {
        }
    }
}
