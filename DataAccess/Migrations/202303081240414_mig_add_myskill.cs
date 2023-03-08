namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig_add_myskill : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MySkills",
                c => new
                    {
                        SkillID = c.Int(nullable: false, identity: true),
                        SkillName = c.String(maxLength: 100),
                        Degree = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SkillID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MySkills");
        }
    }
}
