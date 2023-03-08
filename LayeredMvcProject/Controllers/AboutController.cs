using Business.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using System.Web.Mvc;

namespace LayeredMvcProject.Controllers
{
    public class AboutController : Controller
    {
        AboutManager aboutManager = new AboutManager(new EfAboutDal());
        public ActionResult Index()
        {
            var AboutValues = aboutManager.GetAboutList();
            return View(AboutValues);
        }

        [HttpGet]
        public ActionResult AddAbout()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAbout(About about)
        {
            aboutManager.AddAbout(about);
            return RedirectToAction("Index");
        }

        public PartialViewResult AboutPartial()
        {
            return PartialView();
        }
    }
}