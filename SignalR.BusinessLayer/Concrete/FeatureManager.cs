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
    public class FeatureManager : IFeatureService
    {
        private readonly IFeatureDal _FeatureDal;

        public FeatureManager(IFeatureDal FeatureDal)
        {
            _FeatureDal = FeatureDal;
        }

        public void TAdd(Feature entity)
        {
            _FeatureDal.Add(entity);
        }

        public void TDelete(Feature entity)
        {
            _FeatureDal.Delete(entity);
        }

        public Feature TGetByID(int id)
        {
            return _FeatureDal.GetByID(id);
        }

        public List<Feature> TGetListAll()
        {
            return _FeatureDal.GetListAll();
        }

        public void TUpdate(Feature entity)
        {
            _FeatureDal.Update(entity);
        }
    }
}
