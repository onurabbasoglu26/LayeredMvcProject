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
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void AddAdmin(Admin admin)
        {
            _adminDal.Insert(admin);
        }

        public Admin GetAdminByID(int id)
        {
            return _adminDal.Get(x => x.AdminID == id);
        }

        public List<Admin> GetAdminList()
        {
            return _adminDal.List();
        }

        public void RemoveAdmin(Admin admin)
        {
            _adminDal.Delete(admin);
        }

        public void UpdateAdmin(Admin admin)
        {
            _adminDal.Update(admin);
        }
    }
}
