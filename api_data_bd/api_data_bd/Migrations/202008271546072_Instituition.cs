namespace api_data_bd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Instituition : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Instituition",
                c => new
                {
                    Id = c.String(nullable: false, maxLength: 128),
                    Institute_Name = c.String(nullable: false, maxLength: 256),
                    Institute_type = c.String(nullable: false, maxLength: 256),
                    Establishment = c.String(nullable: false, maxLength: 256),
                    Eiin = c.String(nullable: false, maxLength: 256),
                    Mobile_Number = c.String( maxLength: 256),
                    Management_type = c.String(nullable: false, maxLength: 256),
                    Education_level = c.String(nullable: false, maxLength: 256),
                   

                })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Id, unique: true, name: "InstituitionIdIndexing");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Instituition", "InstituitionIdIndexing");
            DropTable("dbo.Instituition");
           
        }
    }
}
