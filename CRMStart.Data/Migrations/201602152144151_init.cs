namespace CRMStart.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
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
                        UsersProfile_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.UserProfiles", t => t.UsersProfile_Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex")
                .Index(t => t.UsersProfile_Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.PreviousPasswords",
                c => new
                    {
                        PasswordHash = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                        CreateDate = c.DateTimeOffset(nullable: false, precision: 7),
                    })
                .PrimaryKey(t => new { t.PasswordHash, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.UserProfiles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        FirstName = c.String(nullable: false, maxLength: 100),
                        LastName = c.String(nullable: false, maxLength: 100),
                        JobTitle = c.String(),
                        JoinDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TicketActions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ActionTypeId = c.Int(nullable: false),
                        TicketId = c.Int(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Start = c.DateTime(nullable: false),
                        End = c.DateTime(nullable: false),
                        StatusId = c.Int(nullable: false),
                        Details = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TicketActionTypes", t => t.ActionTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Tickets", t => t.TicketId, cascadeDelete: true)
                .ForeignKey("dbo.UserProfiles", t => t.UserId)
                .Index(t => t.ActionTypeId)
                .Index(t => t.TicketId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.TicketActionTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Tickets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        CustomerId = c.Int(),
                        ContactId = c.Int(nullable: false),
                        StatusId = c.Int(nullable: false),
                        Report = c.String(),
                        Urgent = c.Boolean(nullable: false),
                        DateAdded = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.TicketCategories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.Customers", t => t.CustomerId)
                .ForeignKey("dbo.TicketStatus", t => t.StatusId, cascadeDelete: true)
                .Index(t => t.CategoryId)
                .Index(t => t.CustomerId)
                .Index(t => t.StatusId);
            
            CreateTable(
                "dbo.TicketCategories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Archived = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        AccountNumber = c.String(),
                        DateCreated = c.DateTime(nullable: false),
                        MasterAccount = c.Boolean(nullable: false),
                        StatusId = c.Int(nullable: false),
                        CountryId = c.Int(nullable: false),
                        TypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Countries", t => t.CountryId, cascadeDelete: true)
                .ForeignKey("dbo.Status", t => t.StatusId, cascadeDelete: true)
                .ForeignKey("dbo.Types", t => t.TypeId, cascadeDelete: true)
                .Index(t => t.StatusId)
                .Index(t => t.CountryId)
                .Index(t => t.TypeId);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CustomerId = c.Int(nullable: false),
                        Name = c.String(),
                        Email = c.String(),
                        PhoneNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.CustomerId, cascadeDelete: true)
                .Index(t => t.CustomerId);
            
            CreateTable(
                "dbo.Countries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CountryCode = c.String(),
                        CurrencyCode = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Edis",
                c => new
                    {
                        Id = c.Int(nullable: false),
                        DataFtpId = c.Int(nullable: false),
                        OrderFtpId = c.Int(nullable: false),
                        HomeDel = c.Boolean(nullable: false),
                        StockOrd = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Id)
                .Index(t => t.Id);
            
            CreateTable(
                "dbo.DataFtps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EdiId = c.Int(nullable: false),
                        Folder = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Edis", t => t.EdiId, cascadeDelete: true)
                .Index(t => t.EdiId);
            
            CreateTable(
                "dbo.OrderFtps",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EdiId = c.Int(nullable: false),
                        Folder = c.String(),
                        UserName = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Edis", t => t.EdiId, cascadeDelete: true)
                .Index(t => t.EdiId);
            
            CreateTable(
                "dbo.Status",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Order = c.Int(nullable: false),
                        IsDefault = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Types",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TicketStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Order = c.Int(nullable: false),
                        IsDefault = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Articles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CategoryId = c.Int(nullable: false),
                        UniqueReference = c.String(),
                        Title = c.String(),
                        Content = c.String(),
                        UserId = c.String(maxLength: 128),
                        DateAdded = c.DateTime(nullable: false),
                        VersionNumber = c.Int(nullable: false),
                        TagCloud = c.Int(nullable: false),
                        Approved = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .ForeignKey("dbo.UserProfiles", t => t.UserId)
                .Index(t => t.CategoryId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SectionId = c.Int(nullable: false),
                        Name = c.String(),
                        Archived = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sections", t => t.SectionId, cascadeDelete: true)
                .Index(t => t.SectionId);
            
            CreateTable(
                "dbo.Sections",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Archived = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Comments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ArticleId = c.Int(nullable: false),
                        Title = c.String(),
                        Content = c.String(),
                        UserId = c.String(maxLength: 128),
                        DatePosted = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Articles", t => t.ArticleId, cascadeDelete: true)
                .ForeignKey("dbo.UserProfiles", t => t.UserId)
                .Index(t => t.ArticleId)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Roles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        RoleName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUsers", "UsersProfile_Id", "dbo.UserProfiles");
            DropForeignKey("dbo.Articles", "UserId", "dbo.UserProfiles");
            DropForeignKey("dbo.Comments", "UserId", "dbo.UserProfiles");
            DropForeignKey("dbo.Comments", "ArticleId", "dbo.Articles");
            DropForeignKey("dbo.Categories", "SectionId", "dbo.Sections");
            DropForeignKey("dbo.Articles", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.TicketActions", "UserId", "dbo.UserProfiles");
            DropForeignKey("dbo.Tickets", "StatusId", "dbo.TicketStatus");
            DropForeignKey("dbo.Customers", "TypeId", "dbo.Types");
            DropForeignKey("dbo.Tickets", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Customers", "StatusId", "dbo.Status");
            DropForeignKey("dbo.Edis", "Id", "dbo.Customers");
            DropForeignKey("dbo.OrderFtps", "EdiId", "dbo.Edis");
            DropForeignKey("dbo.DataFtps", "EdiId", "dbo.Edis");
            DropForeignKey("dbo.Customers", "CountryId", "dbo.Countries");
            DropForeignKey("dbo.Contacts", "CustomerId", "dbo.Customers");
            DropForeignKey("dbo.Tickets", "CategoryId", "dbo.TicketCategories");
            DropForeignKey("dbo.TicketActions", "TicketId", "dbo.Tickets");
            DropForeignKey("dbo.TicketActions", "ActionTypeId", "dbo.TicketActionTypes");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.PreviousPasswords", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.Comments", new[] { "UserId" });
            DropIndex("dbo.Comments", new[] { "ArticleId" });
            DropIndex("dbo.Categories", new[] { "SectionId" });
            DropIndex("dbo.Articles", new[] { "UserId" });
            DropIndex("dbo.Articles", new[] { "CategoryId" });
            DropIndex("dbo.OrderFtps", new[] { "EdiId" });
            DropIndex("dbo.DataFtps", new[] { "EdiId" });
            DropIndex("dbo.Edis", new[] { "Id" });
            DropIndex("dbo.Contacts", new[] { "CustomerId" });
            DropIndex("dbo.Customers", new[] { "TypeId" });
            DropIndex("dbo.Customers", new[] { "CountryId" });
            DropIndex("dbo.Customers", new[] { "StatusId" });
            DropIndex("dbo.Tickets", new[] { "StatusId" });
            DropIndex("dbo.Tickets", new[] { "CustomerId" });
            DropIndex("dbo.Tickets", new[] { "CategoryId" });
            DropIndex("dbo.TicketActions", new[] { "UserId" });
            DropIndex("dbo.TicketActions", new[] { "TicketId" });
            DropIndex("dbo.TicketActions", new[] { "ActionTypeId" });
            DropIndex("dbo.PreviousPasswords", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", new[] { "UsersProfile_Id" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropTable("dbo.Roles");
            DropTable("dbo.Comments");
            DropTable("dbo.Sections");
            DropTable("dbo.Categories");
            DropTable("dbo.Articles");
            DropTable("dbo.TicketStatus");
            DropTable("dbo.Types");
            DropTable("dbo.Status");
            DropTable("dbo.OrderFtps");
            DropTable("dbo.DataFtps");
            DropTable("dbo.Edis");
            DropTable("dbo.Countries");
            DropTable("dbo.Contacts");
            DropTable("dbo.Customers");
            DropTable("dbo.TicketCategories");
            DropTable("dbo.Tickets");
            DropTable("dbo.TicketActionTypes");
            DropTable("dbo.TicketActions");
            DropTable("dbo.UserProfiles");
            DropTable("dbo.PreviousPasswords");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
        }
    }
}
