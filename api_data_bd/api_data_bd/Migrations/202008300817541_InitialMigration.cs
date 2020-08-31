namespace api_data_bd.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BoardResults",
                c => new
                    {
                        BoardResultId = c.Int(nullable: false, identity: true),
                        Year = c.String(nullable: false),
                        ResultType = c.String(nullable: false),
                        ExamAttendence = c.String(nullable: false),
                        GpaFiveStudentNumber = c.String(nullable: false),
                        FailStudentNumber = c.String(nullable: false),
                        InstituitionId = c.Int(),
                    })
                .PrimaryKey(t => t.BoardResultId)
                .ForeignKey("dbo.Instituitions", t => t.InstituitionId)
                .Index(t => t.InstituitionId);
            
            CreateTable(
                "dbo.Instituitions",
                c => new
                    {
                        InstituitionId = c.Int(nullable: false, identity: true),
                        InstituitionName = c.String(nullable: false),
                        InstituitionEstablishment = c.String(nullable: false),
                        InstituitionType = c.String(nullable: false),
                        InstituitionEiin = c.Int(nullable: false),
                        InstituitionPhoneNumber = c.String(),
                        InstituitionManagementType = c.String(nullable: false),
                        InstituitionEducationLevel = c.String(nullable: false),
                        InstituitionAddressId = c.Int(),
                    })
                .PrimaryKey(t => t.InstituitionId)
                .ForeignKey("dbo.InstituitionsAddresses", t => t.InstituitionAddressId)
                .Index(t => t.InstituitionAddressId);
            
            CreateTable(
                "dbo.InstituitionsAddresses",
                c => new
                    {
                        InstituitionAddressId = c.Int(nullable: false, identity: true),
                        InstituitionAddressUnion = c.String(nullable: false),
                        InstituitionAddressThana = c.String(nullable: false),
                        InstituitionAddressDivision = c.String(nullable: false),
                        InstituitionAddressDistrict = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.InstituitionAddressId);
            
            CreateTable(
                "dbo.InstituteStatistics",
                c => new
                    {
                        InstituteStatisticsId = c.Int(nullable: false, identity: true),
                        InstituteStatisticsMaleTeacher = c.String(nullable: false),
                        InstituteStatisticsFemaleTeacher = c.String(nullable: false),
                        InstituteStatisticsYear = c.String(nullable: false),
                        InstituteStatisticsBoysStudent = c.String(),
                        InstituteStatisticsGirlsStudent = c.String(),
                        InstituitionId = c.Int(),
                    })
                .PrimaryKey(t => t.InstituteStatisticsId)
                .ForeignKey("dbo.Instituitions", t => t.InstituitionId)
                .Index(t => t.InstituitionId);
            
            CreateTable(
                "dbo.OAUTH_Roles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.OAUTH_UserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.OAUTH_Roles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.OAUTH_Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        StudentId = c.Int(nullable: false, identity: true),
                        StudentName = c.String(),
                        StudentAge = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StudentId);
            
            CreateTable(
                "dbo.OAUTH_Users",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.OAUTH_UserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.OAUTH_Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.OAUTH_UserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.OAUTH_Users", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OAUTH_UserRoles", "UserId", "dbo.OAUTH_Users");
            DropForeignKey("dbo.OAUTH_UserLogins", "UserId", "dbo.OAUTH_Users");
            DropForeignKey("dbo.OAUTH_UserClaims", "UserId", "dbo.OAUTH_Users");
            DropForeignKey("dbo.OAUTH_UserRoles", "RoleId", "dbo.OAUTH_Roles");
            DropForeignKey("dbo.InstituteStatistics", "InstituitionId", "dbo.Instituitions");
            DropForeignKey("dbo.Instituitions", "InstituitionAddressId", "dbo.InstituitionsAddresses");
            DropForeignKey("dbo.BoardResults", "InstituitionId", "dbo.Instituitions");
            DropIndex("dbo.OAUTH_UserLogins", new[] { "UserId" });
            DropIndex("dbo.OAUTH_UserClaims", new[] { "UserId" });
            DropIndex("dbo.OAUTH_Users", "UserNameIndex");
            DropIndex("dbo.OAUTH_UserRoles", new[] { "RoleId" });
            DropIndex("dbo.OAUTH_UserRoles", new[] { "UserId" });
            DropIndex("dbo.OAUTH_Roles", "RoleNameIndex");
            DropIndex("dbo.InstituteStatistics", new[] { "InstituitionId" });
            DropIndex("dbo.Instituitions", new[] { "InstituitionAddressId" });
            DropIndex("dbo.BoardResults", new[] { "InstituitionId" });
            DropTable("dbo.OAUTH_UserLogins");
            DropTable("dbo.OAUTH_UserClaims");
            DropTable("dbo.OAUTH_Users");
            DropTable("dbo.Students");
            DropTable("dbo.OAUTH_UserRoles");
            DropTable("dbo.OAUTH_Roles");
            DropTable("dbo.InstituteStatistics");
            DropTable("dbo.InstituitionsAddresses");
            DropTable("dbo.Instituitions");
            DropTable("dbo.BoardResults");
        }
    }
}
