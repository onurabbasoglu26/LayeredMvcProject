using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAdminService
    {
        List<Admin> GetAdminList();
        Admin GetAdminByID(int id);
        void AddAdmin(Admin admin);
        void RemoveAdmin(Admin admin);
        void UpdateAdmin(Admin admin);
    }
}
