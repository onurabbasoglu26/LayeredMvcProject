using Business.Concrete;
using Business.ValidationRules;
using DataAccess.EntityFramework;
using Entity.Concrete;
using FluentValidation.Results;
using System.Web.Mvc;

namespace LayeredMvcProject.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

        [Authorize(Roles = "B")]
        public ActionResult Index()
        {
            var categoryvalues = categoryManager.GetCategoryList();
            return View(categoryvalues);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            CategoryValidator categoryValidator = new CategoryValidator();
            ValidationResult validationResult = categoryValidator.Validate(category);
            if (validationResult.IsValid)
            {

                categoryManager.AddCategory(category);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in validationResult.Errors)
                {
                    ModelState.AddModelError(item.PropertyName, item.ErrorMessage);
                }
            }
            return View();
        }

        public ActionResult DeleteCategory(int id)
        {
            var categoryvalues = categoryManager.GetCategoryById(id);
            categoryManager.RemoveCategory(categoryvalues);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult EditCategory(int id)
        {
            var categoryvalue = categoryManager.GetCategoryById(id);
            return View(categoryvalue);
        }

        [HttpPost]
        public ActionResult EditCategory(Category category)
        {
            categoryManager.UpdateCategory(category);
            return RedirectToAction("Index");
        }
    }
}