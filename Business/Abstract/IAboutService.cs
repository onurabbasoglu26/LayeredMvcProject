using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IAboutService
    {
        List<About> GetAboutList();
        About GetAboutById(int id);
        void AddAbout(About about);
        void RemoveAbout(About about);
        void UpdateAbout(About about);
    }
}
