using Business.Concrete;
using Business.ValidationRules;
using DataAccess.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;
using System.Web.Mvc;

namespace LayeredMvcProject.Controllers
{
    public class WriterController : Controller
    {
        WriterManager writerManager = new WriterManager(new EfWriterDal());
        WriterValidator writerValidation = new WriterValidator();
        public ActionResult Index()
        {
            var WriterValues = writerManager.GetWriterList();
            return View(WriterValues);
        }

        [HttpGet]
        public ActionResult AddWriter()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddWriter(Writer writer)
        {
            ValidationResult results = writerValidation.Validate(writer);
            if (results.IsValid)
            {
                writerManager.AddWriter(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        [HttpGet]
        public ActionResult EditWriter(int id)
        {
            var writerValue = writerManager.GetWriterById(id);
            return View(writerValue);
        }

        [HttpPost]
        public ActionResult EditWriter(Writer writer)
        {
            ValidationResult results = writerValidation.Validate(writer);
            if (results.IsValid)
            {
                writerManager.UpdateWriter(writer);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in results.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }
    }
}