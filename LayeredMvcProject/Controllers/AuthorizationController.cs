using Business.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LayeredMvcProject.Controllers
{
    public class AuthorizationController : Controller
    {
        AdminManager adminManager = new AdminManager(new EfAdminDal());
        public ActionResult Index()
        {
            var adminValues = adminManager.GetAdminList();
            return View(adminValues);
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(Admin admin)
        {
            adminManager.AddAdmin(admin);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditAdmin(int id)
        {
            var adminValue = adminManager.GetAdminByID(id);
            return View(adminValue);
        }

        [HttpPost]
        public ActionResult EditAdmin(Admin admin)
        {
            adminManager.UpdateAdmin(admin);
            return RedirectToAction("Index");
        }
    }
}