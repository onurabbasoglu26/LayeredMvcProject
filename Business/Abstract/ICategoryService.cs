using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetCategoryList();
        Category GetCategoryById(int id);
        void AddCategory(Category category);
        void RemoveCategory(Category category);
        void UpdateCategory(Category category);
    }
}
