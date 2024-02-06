using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntitiyLayer.Entities;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class MoneyCaseManager : IMoneyCaseService
    {
        private readonly IMoneyCaseDal _MoneyCaseDal;

        public MoneyCaseManager(IMoneyCaseDal MoneyCaseDal)
        {
            _MoneyCaseDal = MoneyCaseDal;
        }

        public void TAdd(MoneyCase entity)
        {
            _MoneyCaseDal.Add(entity);
        }

        public void TDelete(MoneyCase entity)
        {
            _MoneyCaseDal.Delete(entity);
        }

        public MoneyCase TGetByID(int id)
        {
            return _MoneyCaseDal.GetByID(id);
        }

        public List<MoneyCase> TGetListAll()
        {
            return _MoneyCaseDal.GetListAll();
        }

        public decimal TTotalMoneyCaseAmount()
        {
            return _MoneyCaseDal.TotalMoneyCaseAmount();
        }

        public void TUpdate(MoneyCase entity)
        {
            _MoneyCaseDal.Update(entity);
        }
    }
}
