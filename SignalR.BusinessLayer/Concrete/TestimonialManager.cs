using SignalR.BusinessLayer.Abstract;
using SignalR.DataAccessLayer.Abstract;
using SignalR.EntityLayer.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BusinessLayer.Concrete
{
    public class TestimonialManager : ITestimonialService
    {
        private readonly ITestimonialDal _TestimonialDal;

        public TestimonialManager(ITestimonialDal TestimonialDal)
        {
            _TestimonialDal = TestimonialDal;
        }

        public void TAdd(Testimonial entity)
        {
            _TestimonialDal.Add(entity);
        }

        public void TDelete(Testimonial entity)
        {
            _TestimonialDal.Delete(entity);
        }

        public Testimonial TGetByID(int id)
        {
            return _TestimonialDal.GetByID(id);
        }

        public List<Testimonial> TGetListAll()
        {
            return _TestimonialDal.GetListAll();
        }

        public void TUpdate(Testimonial entity)
        {
            _TestimonialDal.Update(entity);
        }
    }
}
