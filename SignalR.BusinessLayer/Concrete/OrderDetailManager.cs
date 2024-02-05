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
    public class OrderDetailManager : IOrderDetailService
    {
        private readonly IOrderDetailDal _OrderDetailDal;

        public OrderDetailManager(IOrderDetailDal OrderDetailDal)
        {
            _OrderDetailDal = OrderDetailDal;
        }

        public void TAdd(OrderDetail entity)
        {
            _OrderDetailDal.Add(entity);
        }

        public void TDelete(OrderDetail entity)
        {
            _OrderDetailDal.Delete(entity);
        }

        public OrderDetail TGetByID(int id)
        {
            return _OrderDetailDal.GetByID(id);
        }

        public List<OrderDetail> TGetListAll()
        {
            return _OrderDetailDal.GetListAll();
        }

        public void TUpdate(OrderDetail entity)
        {
            _OrderDetailDal.Update(entity);
        }
    }
}
