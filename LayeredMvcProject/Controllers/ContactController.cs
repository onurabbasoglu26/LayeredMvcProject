using Business.Concrete;
using Business.ValidationRules;
using DataAccess.EntityFramework;
using System.Web.Mvc;

namespace LayeredMvcProject.Controllers
{
    public class ContactController : Controller
    {
        ContactManager contactManager = new ContactManager(new EfContactDal());
        ContactValidator contactValidator = new ContactValidator();
        public ActionResult Index()
        {
            var ContactValues = contactManager.GetContactList();
            return View(ContactValues);
        }

        public ActionResult Details(int id)
        {
            var ContactValues = contactManager.GetContactById(id);
            return View(ContactValues);
        }

        public PartialViewResult MenuPartial()
        {
            return PartialView();
        }
    }
}