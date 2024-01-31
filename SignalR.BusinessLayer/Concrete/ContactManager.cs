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
    public class ContactManager : IContactService
    {
        private readonly IContactDal _ContactDal;

        public ContactManager(IContactDal ContactDal)
        {
            _ContactDal = ContactDal;
        }

        public void TAdd(Contact entity)
        {
            _ContactDal.Add(entity);
        }

        public void TDelete(Contact entity)
        {
            _ContactDal.Delete(entity);
        }

        public Contact TGetByID(int id)
        {
            return _ContactDal.GetByID(id);
        }

        public List<Contact> TGetListAll()
        {
            return _ContactDal.GetListAll();
        }

        public void TUpdate(Contact entity)
        {
            _ContactDal.Update(entity);
        }
    }
}
