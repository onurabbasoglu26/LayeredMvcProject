using Business.Concrete;
using Business.ValidationRules;
using DataAccess.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace LayeredMvcProject.Controllers
{
    public class WriterPanelController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        readonly CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        readonly WriterManager writerManager = new WriterManager(new EfWriterDal());

        [HttpGet]
        public ActionResult WriterProfile(int id = 0)
        {
            string p = (string)Session["WriterMail"];
            id = writerManager.GetWriterList().Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var writerValue = writerManager.GetWriterById(id);
            return View(writerValue);
        }

        [HttpPost]
        public ActionResult WriterProfile(Writer writer)
        {
            WriterValidator writerValidation = new WriterValidator();
            ValidationResult results = writerValidation.Validate(writer);
            if (results.IsValid)
            {
                writerManager.UpdateWriter(writer);
                return RedirectToAction("WriterProfile");
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

        public ActionResult MyHeading(string p)
        {
            p = (string)Session["WriterMail"];
            var WriterIdInfo = writerManager.GetWriterList().Where(x => x.WriterMail == p).Select(y => y.WriterID).FirstOrDefault();
            var values = headingManager.GetHeadingListByWriter(WriterIdInfo);
            return View(values);
        }

        [HttpGet]
        public ActionResult NewHeading()
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetCategoryList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCategory;
            return View();
        }

        [HttpPost]
        public ActionResult NewHeading(Heading heading)
        {
            string WriterMailInfo = (string)Session["WriterMail"];
            var WriterIdInfo = writerManager.GetWriterList().Where(x => x.WriterMail == WriterMailInfo).Select(y => y.WriterID).FirstOrDefault();
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.WriterID = WriterIdInfo;
            heading.HeadingStatus = true;
            headingManager.AddHeading(heading);
            return RedirectToAction("MyHeading");
        }

        [HttpGet]
        public ActionResult EditHeading(int id)
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetCategoryList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();
            ViewBag.vlc = valueCategory;
            var HeadingValue = headingManager.GetHeadingById(id);
            return View(HeadingValue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            headingManager.UpdateHeading(heading);
            return RedirectToAction("MyHeading", "WriterPanel");
        }

        public ActionResult DeleteHeading(int id)
        {
            var HeadingValue = headingManager.GetHeadingById(id);
            HeadingValue.HeadingStatus = false;
            headingManager.UpdateHeading(HeadingValue);
            return RedirectToAction("MyHeading");
        }

        public ActionResult AllHeading(int p = 1)
        {
            var Headings = headingManager.GetHeadingList().ToPagedList(p, 4);
            return View(Headings);
        }

    }
}