using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IContactService
    {
        List<Contact> GetContactList();
        Contact GetContactById(int id);
        void AddContact(Contact contact);
        void RemoveContact(Contact contact);
        void UpdateContact(Contact contact);
    }
}
