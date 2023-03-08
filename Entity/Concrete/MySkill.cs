using System.ComponentModel.DataAnnotations;

namespace Entity.Concrete
{
    public class MySkill
    {
        [Key]
        public int SkillID { get; set; }

        [StringLength(100)]
        public string SkillName { get; set; }

        public int Degree { get; set; }
    }
}
