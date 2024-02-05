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
    public class OrderManager : IOrderService
    {
        private readonly IOrderDal _OrderDal;

        public OrderManager(IOrderDal OrderDal)
        {
            _OrderDal = OrderDal;
        }

        public int TActiveOrderCount()
        {
            return _OrderDal.ActiveOrderCount();
        }

        public void TAdd(Order entity)
        {
            _OrderDal.Add(entity);
        }

        public void TDelete(Order entity)
        {
            _OrderDal.Delete(entity);
        }

        public Order TGetByID(int id)
        {
            return _OrderDal.GetByID(id);
        }

        public List<Order> TGetListAll()
        {
            return _OrderDal.GetListAll();
        }

        public decimal TLastOrderPrice()
        {
            return _OrderDal.LastOrderPrice();
        }

        public int TTotalOrderCount()
        {
            return _OrderDal.TotalOrderCount();
        }

        public void TUpdate(Order entity)
        {
            _OrderDal.Update(entity);
        }
    }
}
