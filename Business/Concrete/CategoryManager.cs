using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;

        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }

        public void AddCategory(Category category)
        {
            _categoryDal.Insert(category);
        }

        public Category GetCategoryById(int id)
        {
            return _categoryDal.Get(x => x.CategoryID == id);
        }

        public List<Category> GetCategoryList()
        {
            return _categoryDal.List();
        }

        public void RemoveCategory(Category category)
        {
            _categoryDal.Delete(category);
        }

        public void UpdateCategory(Category category)
        {
            _categoryDal.Update(category);
        }
    }
}
