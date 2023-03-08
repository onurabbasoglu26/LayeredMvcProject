using Business.Concrete;
using DataAccess.EntityFramework;
using System.Web.Mvc;

namespace LayeredMvcProject.Controllers
{
    [AllowAnonymous]
    public class DefaultController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        ContentManager contentManager = new ContentManager(new EfContentDal());

        public ActionResult Headings()
        {
            var HeadingList = headingManager.GetHeadingList();
            return View(HeadingList);
        }
        public PartialViewResult Index(int id = 0)
        {
            var ContentList = contentManager.GetListByHeadingId(id);
            return PartialView(ContentList);
        }
    }
}