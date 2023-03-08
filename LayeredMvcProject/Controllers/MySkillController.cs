using Business.Concrete;
using DataAccess.EntityFramework;
using System.Web.Mvc;

namespace LayeredMvcProject.Controllers
{
    public class MySkillController : Controller
    {
        MySkillManager mySkillManager = new MySkillManager(new EfMySkillDal());
        public ActionResult Index()
        {
            var result = mySkillManager.GetMySkills();
            return View(result);
        }
    }
}