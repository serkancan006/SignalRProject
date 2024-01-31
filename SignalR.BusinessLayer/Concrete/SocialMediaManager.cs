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
    public class SocialMediaManager : ISocialMediaService
    {
        private readonly ISocialMediaDal _SocialMediaDal;

        public SocialMediaManager(ISocialMediaDal SocialMediaDal)
        {
            _SocialMediaDal = SocialMediaDal;
        }

        public void TAdd(SocialMedia entity)
        {
            _SocialMediaDal.Add(entity);
        }

        public void TDelete(SocialMedia entity)
        {
            _SocialMediaDal.Delete(entity);
        }

        public SocialMedia TGetByID(int id)
        {
            return _SocialMediaDal.GetByID(id);
        }

        public List<SocialMedia> TGetListAll()
        {
            return _SocialMediaDal.GetListAll();
        }

        public void TUpdate(SocialMedia entity)
        {
            _SocialMediaDal.Update(entity);
        }
    }
}
