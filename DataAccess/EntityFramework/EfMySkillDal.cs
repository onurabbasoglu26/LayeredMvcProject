using DataAccess.Abstract;
using DataAccess.Concrete.Repositories;
using Entity.Concrete;

namespace DataAccess.EntityFramework
{
    public class EfMySkillDal : GenericRepository<MySkill>, IMySkillDal
    {
    }
}
