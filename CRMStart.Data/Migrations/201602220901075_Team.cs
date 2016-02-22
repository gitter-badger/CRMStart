namespace CRMStart.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Team : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Teams",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateCreated = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TeamCrmStartUsers",
                c => new
                    {
                        Team_Id = c.Int(nullable: false),
                        CrmStartUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Team_Id, t.CrmStartUser_Id })
                .ForeignKey("dbo.Teams", t => t.Team_Id, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.CrmStartUser_Id, cascadeDelete: true)
                .Index(t => t.Team_Id)
                .Index(t => t.CrmStartUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TeamCrmStartUsers", "CrmStartUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.TeamCrmStartUsers", "Team_Id", "dbo.Teams");
            DropIndex("dbo.TeamCrmStartUsers", new[] { "CrmStartUser_Id" });
            DropIndex("dbo.TeamCrmStartUsers", new[] { "Team_Id" });
            DropTable("dbo.TeamCrmStartUsers");
            DropTable("dbo.Teams");
        }
    }
}
