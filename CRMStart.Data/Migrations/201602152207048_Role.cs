namespace CRMStart.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Role : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Roles");
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.RoleContacts",
                c => new
                    {
                        Role_Id = c.Int(nullable: false),
                        Contact_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Role_Id, t.Contact_Id })
                .ForeignKey("dbo.Roles", t => t.Role_Id, cascadeDelete: true)
                .ForeignKey("dbo.Contacts", t => t.Contact_Id, cascadeDelete: true)
                .Index(t => t.Role_Id)
                .Index(t => t.Contact_Id);
            
         
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            DropForeignKey("dbo.RoleContacts", "Contact_Id", "dbo.Contacts");
            DropForeignKey("dbo.RoleContacts", "Role_Id", "dbo.Roles");
            DropIndex("dbo.RoleContacts", new[] { "Contact_Id" });
            DropIndex("dbo.RoleContacts", new[] { "Role_Id" });
            DropTable("dbo.RoleContacts");
            DropTable("dbo.Roles");
        }
    }
}
