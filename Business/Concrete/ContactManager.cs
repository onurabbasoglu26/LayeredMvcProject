using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void AddContact(Contact contact)
        {
            _contactDal.Insert(contact);
        }

        public Contact GetContactById(int id)
        {
            return _contactDal.Get(x => x.ContactID == id);
        }

        public List<Contact> GetContactList()
        {
            return _contactDal.List();
        }

        public void RemoveContact(Contact contact)
        {
            _contactDal.Delete(contact);
        }

        public void UpdateContact(Contact contact)
        {
            _contactDal.Update(contact);
        }
    }
}
