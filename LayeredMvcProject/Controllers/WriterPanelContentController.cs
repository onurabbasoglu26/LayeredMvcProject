using Business.Concrete;
using DataAccess.EntityFramework;
using Entity.Concrete;
using System;
using System.Linq;
using System.Web.Mvc;

namespace LayeredMvcProject.Controllers
{
    public class WriterPanelContentController : Controller
    {
        ContentManager contentManager = new ContentManager(new EfContentDal());
        readonly WriterManager WriterManager = new WriterManager(new EfWriterDal());
        public ActionResult MyContent(string p)
        {
            p = (string)Session["WriterMail"];
            var WriterIdInfo = WriterManager.GetWriterList().Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var contentValues = contentManager.GetContentListWriter(WriterIdInfo);
            return View(contentValues);
        }

        [HttpGet]
        public ActionResult AddContent(int id)
        {
            ViewBag.d = id;
            return View();
        }

        [HttpPost]
        public ActionResult AddContent(Content content)
        {
            string Mail = (string)Session["WriterMail"];
            var WriterIdInfo = WriterManager.GetWriterList().Where(x => x.WriterMail == Mail).Select(y => y.WriterID).FirstOrDefault();
            content.ContentDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            content.WriterID = WriterIdInfo;
            content.ContentStatus = true;
            contentManager.AddContent(content);
            return RedirectToAction("MyContent");
        }
    }
}