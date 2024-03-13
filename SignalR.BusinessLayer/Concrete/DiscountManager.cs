using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntitiyLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class DiscountManager : IDiscountService
    {
        private readonly IDiscountDal _DiscountDal;

        public DiscountManager(IDiscountDal DiscountDal)
        {
            _DiscountDal = DiscountDal;
        }

        public void TAdd(Discount entity)
        {
            _DiscountDal.Add(entity);
        }

        public void TChangeStatusToFalse(int id)
        {
            _DiscountDal.ChangeStatusToFalse(id);
        }

        public void TChangeStatusToTrue(int id)
        {
            _DiscountDal.ChangeStatusToTrue(id);
        }

        public void TDelete(Discount entity)
        {
            _DiscountDal.Delete(entity);
        }

        public Discount TGetByID(int id)
        {
            return _DiscountDal.GetByID(id);
        }

        public List<Discount> TGetListAll()
        {
            return _DiscountDal.GetListAll();
        }

        public List<Discount> TGetListByStatusTrue()
        {
            return _DiscountDal.GetListByStatusTrue();
        }

        public void TUpdate(Discount entity)
        {
            _DiscountDal.Update(entity);
        }
    }
}
