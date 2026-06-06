using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Final_Project_CORE.Infrastructure.Repositories;
using Final_Project_CORE.Models;
using Final_Project_CORE.Utility;

namespace Final_Project_CORE.Infrastructure.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        InvContext _context;
        public UnitOfWork(InvContext context)
        { this._context = context; 
            
        }
        #region properties
        public ICateRepo? cateRepo;
        public ICateRepo CateRepo
        {
            get
            {
                if (cateRepo == null)
                {
                    cateRepo = new CateRepo(_context);
                }
                return cateRepo;
            }
        }
        #endregion
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }
        }

        public Modelmessage Save()
        {
         Modelmessage modelMessage = new Modelmessage();
            try
            {
                if (_context.SaveChanges() > 0)
                {
                    modelMessage.Message = $"Operation Successfull ";
                    modelMessage.IsSuccess = true;
                }
                else
                {
                    modelMessage.Message = $"Operation failled  ";
                    modelMessage.IsSuccess = false;
                }
            }
            catch (Exception ex)
            {
                if (ex.InnerException != null)
                {
                    modelMessage.Message = ex.InnerException.Message;
                    modelMessage.IsSuccess = false;
                }
                else
                {
                    modelMessage.Message = ex.Message;
                    modelMessage.IsSuccess = false;
                }
            }
            return modelMessage;
        }
    }
}
