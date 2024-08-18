using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using FluentValidation;
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
        IValidator<Stock> _validator;

        public StockManager(IStockDAL stockDal,IValidator<Stock> validator)
        {

            _stockDal = stockDal;
            _validator = validator;
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
            var validationresult=_validator.Validate(stock);
            if (!validationresult.IsValid)
            {
                throw new ValidationException(validationresult.Errors);
            }
            _stockDal.Add(stock);
            
        }

        public void StockRemove(Stock stock)
        {
            _stockDal.Delete(stock);
        }

        public void StockUpdate(Stock stock)
        {
            var validationresult = _validator.Validate(stock);
            if (!validationresult.IsValid)
            {
                throw new ValidationException(validationresult.Errors);
            }
            _stockDal.Update(stock);
        }
    }
}
