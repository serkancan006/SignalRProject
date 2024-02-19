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
    public class SliderManager : ISliderService
    {
        private readonly ISliderDal _SliderDal;

        public SliderManager(ISliderDal SliderDal)
        {
            _SliderDal = SliderDal;
        }

        public void TAdd(Slider entity)
        {
            _SliderDal.Add(entity);
        }

        public void TDelete(Slider entity)
        {
            _SliderDal.Delete(entity);
        }

        public Slider TGetByID(int id)
        {
            return _SliderDal.GetByID(id);
        }

        public List<Slider> TGetListAll()
        {
            return _SliderDal.GetListAll();
        }

        public void TUpdate(Slider entity)
        {
            _SliderDal.Update(entity);
        }
    }
}
