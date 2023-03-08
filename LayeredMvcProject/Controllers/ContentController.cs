using Business.Concrete;
using DataAccess.EntityFramework;
using System.Linq;
using System.Web.Mvc;

namespace LayeredMvcProject.Controllers
{
    public class ContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());

        public ActionResult GetAllContent(string p)
        {
            var values = contentManager.GetContentList();
            if (!string.IsNullOrEmpty(p))
            {
                values = contentManager.GetContentList(p);
            }
            return View(values.ToList());
        }

        public ActionResult ContentByHeading(int id)
        {
            var contentValues = contentManager.GetListByHeadingId(id);
            return View(contentValues);
        }
    }
}