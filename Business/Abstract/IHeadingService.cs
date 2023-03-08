using Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IHeadingService
    {
        List<Heading> GetHeadingList();
        List<Heading> GetHeadingListByWriter(int id);
        void AddHeading(Heading heading);
        void RemoveHeading(Heading heading);
        void UpdateHeading(Heading heading);
        Heading GetHeadingById(int id);
    }
}
