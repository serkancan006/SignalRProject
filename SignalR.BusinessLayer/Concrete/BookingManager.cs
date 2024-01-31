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
    public class BookingManager : IBookingService
    {
        private readonly IBookingDal _BookingDal;

        public BookingManager(IBookingDal BookingDal)
        {
            _BookingDal = BookingDal;
        }

        public void TAdd(Booking entity)
        {
            _BookingDal.Add(entity);
        }

        public void TDelete(Booking entity)
        {
            _BookingDal.Delete(entity);
        }

        public Booking TGetByID(int id)
        {
            return _BookingDal.GetByID(id);
        }

        public List<Booking> TGetListAll()
        {
            return _BookingDal.GetListAll();
        }

        public void TUpdate(Booking entity)
        {
            _BookingDal.Update(entity);
        }
    }
}
