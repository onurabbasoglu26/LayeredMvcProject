using System.Collections.Generic;
using System.Web.Mvc;
using LayeredMvcProject.Models;

namespace LayeredMvcProject.Controllers
{
    public class ChartController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult CategoryChart()
        {
            return Json(BlogList(), JsonRequestBehavior.AllowGet);
        }

        public List<CategoryChart> BlogList()
        {
            List<CategoryChart> categoryCharts = new List<CategoryChart>();
            categoryCharts.Add(new CategoryChart()
            {
                CategoryName = "Yazılım",
                CategoryCount = 8
            });
            categoryCharts.Add(new CategoryChart()
            {
                CategoryName = "Seyahat",
                CategoryCount = 4
            });
            categoryCharts.Add(new CategoryChart()
            {
                CategoryName = "Teknoloji",
                CategoryCount = 7
            });
            categoryCharts.Add(new CategoryChart()
            {
                CategoryName = "Spor",
                CategoryCount = 1
            });
            return categoryCharts;
        }
    }
}