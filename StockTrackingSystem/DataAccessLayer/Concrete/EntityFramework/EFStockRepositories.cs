using Core.DataAccess;
using Core.DataAccess.EntityFramework;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.EntityFramework
{
    public class EFStockRepositories :EFEntityRepositoryBase<Stock , Context> ,IStockDAL
    {
        private readonly Context _context;
        public EFStockRepositories(Context context) : base(context)
        {
            this._context = context;
        }
    }
}
