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
    public class HeadingController : Controller
    {
        HeadingManager headingManager = new HeadingManager(new EfHeadingDal());
        readonly CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());
        readonly WriterManager writerManager = new WriterManager(new EfWriterDal());
        public ActionResult Index()
        {
            var headingValues = headingManager.GetHeadingList();
            return View(headingValues);
        }

        public ActionResult HeadingReport()
        {
            var headingValues = headingManager.GetHeadingList();
            return View(headingValues);
        }

        [HttpGet]
        public ActionResult AddHeading()
        {
            List<SelectListItem> valueCategory = (from x in categoryManager.GetCategoryList()
                                                  select new SelectListItem
                                                  {
                                                      Text = x.CategoryName,
                                                      Value = x.CategoryID.ToString()
                                                  }).ToList();

            List<SelectListItem> valueWriter = (from x in writerManager.GetWriterList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + " " + x.WriterSurname,
                                                    Value = x.WriterID.ToString()
                                                }).ToList();
            ViewBag.vlw = valueWriter;
            ViewBag.vlc = valueCategory;
            return View();
        }

        [HttpPost]
        public ActionResult AddHeading(Heading heading)
        {
            heading.HeadingDate = DateTime.Parse(DateTime.Now.ToShortDateString());
            heading.HeadingStatus = true;
            headingManager.AddHeading(heading);
            return RedirectToAction("Index", "Heading");
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

            List<SelectListItem> valueWriter = (from x in writerManager.GetWriterList()
                                                select new SelectListItem
                                                {
                                                    Text = x.WriterName + " " + x.WriterSurname,
                                                    Value = x.WriterID.ToString()
                                                }).ToList();
            ViewBag.vlw = valueWriter;
            ViewBag.vlc = valueCategory;
            var HeadingValue = headingManager.GetHeadingById(id);
            return View(HeadingValue);
        }

        [HttpPost]
        public ActionResult EditHeading(Heading heading)
        {
            heading.HeadingStatus = true;
            headingManager.UpdateHeading(heading);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteHeading(int id)
        {
            var HeadingValue = headingManager.GetHeadingById(id);
            if (HeadingValue.HeadingStatus == true)
            {
                HeadingValue.HeadingStatus = false;
            }
            else if (HeadingValue.HeadingStatus == false)
            {
                HeadingValue.HeadingStatus = true;
            }
            headingManager.UpdateHeading(HeadingValue);
            return RedirectToAction("Index");
        }
    }
}