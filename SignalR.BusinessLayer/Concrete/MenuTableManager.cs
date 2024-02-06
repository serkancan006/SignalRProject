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
    public class MenuTableManager : IMenuTableService
    {
        private readonly IMenuTableDal _MenuTableDal;

        public MenuTableManager(IMenuTableDal MenuTableDal)
        {
            _MenuTableDal = MenuTableDal;
        }

        public void TAdd(MenuTable entity)
        {
            _MenuTableDal.Add(entity);
        }

        public void TDelete(MenuTable entity)
        {
            _MenuTableDal.Delete(entity);
        }

        public MenuTable TGetByID(int id)
        {
            return _MenuTableDal.GetByID(id);
        }

        public List<MenuTable> TGetListAll()
        {
            return _MenuTableDal.GetListAll();
        }

        public int TMenuTableCount()
        {
            return _MenuTableDal.MenuTableCount();
        }

        public void TUpdate(MenuTable entity)
        {
            _MenuTableDal.Update(entity);
        }
    }
}
