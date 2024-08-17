using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    
    public class StockManager : IStockService
    {
        IStockDAL _stockDal;
        

        public StockManager(IStockDAL stockDal)
        {
            _stockDal = stockDal;
        }

        public Stock GetById(int id)
        {
           return _stockDal.Get(p=>p.ID == id);
        }

        public List<Stock> GetStocks()
        {
            return _stockDal.GetAll();
        }

        public void StockAdd(Stock stock)
        {
            _stockDal.Add(stock);
            
        }

        public void StockRemove(Stock stock)
        {
            _stockDal.Delete(stock);
        }

        public void StockUpdate(Stock stock)
        {
            _stockDal.Update(stock);
        }
    }
}
