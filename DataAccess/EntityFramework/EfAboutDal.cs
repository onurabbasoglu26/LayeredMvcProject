using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;
using Entity.Concrete;

namespace DataAccess.EntityFramework
{
    public class EfAboutDal : GenericRepository<About>, IAboutDal
    {
    }
}
