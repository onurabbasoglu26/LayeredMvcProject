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
    public class MySkillManager : IMySkillService
    {
        IMySkillDal _mySkillDal;

        public MySkillManager(IMySkillDal mySkillDal)
        {
            this._mySkillDal = mySkillDal;
        }

        public List<MySkill> GetMySkills()
        {
            return _mySkillDal.List();
        }
    }
}
