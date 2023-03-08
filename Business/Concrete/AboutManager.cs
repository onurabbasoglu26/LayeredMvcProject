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
    public class AboutManager : IAboutService
    {
        IAboutDal _aboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }

        public void AddAbout(About about)
        {
            _aboutDal.Insert(about);
        }

        public About GetAboutById(int id)
        {
            return _aboutDal.Get(x => x.AboutID == id);
        }

        public List<About> GetAboutList()
        {
            return _aboutDal.List();
        }

        public void RemoveAbout(About about)
        {
            _aboutDal.Delete(about);
        }

        public void UpdateAbout(About about)
        {
            _aboutDal.Update(about);
        }
    }
}
