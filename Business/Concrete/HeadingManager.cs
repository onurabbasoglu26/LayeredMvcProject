using Business.Abstract;
using DataAccess.Abstract;
using Entity.Concrete;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class HeadingManager : IHeadingService
    {
        IHeadingDal _headingDal;

        public HeadingManager(IHeadingDal headingDal)
        {
            _headingDal = headingDal;
        }

        public void AddHeading(Heading heading)
        {
            _headingDal.Insert(heading);
        }

        public Heading GetHeadingById(int id)
        {
            return _headingDal.Get(x => x.HeadingID == id);
        }

        public List<Heading> GetHeadingList()
        {
            return _headingDal.List();
        }

        public List<Heading> GetHeadingListByWriter(int id)
        {
            return _headingDal.List(x => x.WriterID == id);
        }

        public void RemoveHeading(Heading heading)
        {
            _headingDal.Delete(heading);
        }

        public void UpdateHeading(Heading heading)
        {
            _headingDal.Update(heading);
        }
    }
}
