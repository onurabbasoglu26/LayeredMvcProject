using Business.Concrete;
using DataAccess.EntityFramework;
using System.Web.Mvc;

namespace LayeredMvcProject.Controllers
{
    public class GaleryController : Controller
    {
        ImageFileManager imageFileManager = new ImageFileManager(new EfImageFileDal());
        public ActionResult Index()
        {
            var files = imageFileManager.GetImageFileList();
            return View(files);
        }
    }
}