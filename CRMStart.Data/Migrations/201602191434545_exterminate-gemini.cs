namespace CRMStart.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class exterminategemini : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.DataFtps", "EdiId", "dbo.Edis");
            DropForeignKey("dbo.OrderFtps", "EdiId", "dbo.Edis");
            DropForeignKey("dbo.Edis", "Id", "dbo.Customers");
            DropIndex("dbo.Edis", new[] { "Id" });
            DropIndex("dbo.DataFtps", new[] { "EdiId" });
            DropIndex("dbo.OrderFtps", new[] { "EdiId" });
            DropTable("dbo.Edis");
            DropTable("dbo.DataFtps");
            DropTable("dbo.OrderFtps");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.Id);
            
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
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.OrderFtps", "EdiId");
            CreateIndex("dbo.DataFtps", "EdiId");
            CreateIndex("dbo.Edis", "Id");
            AddForeignKey("dbo.Edis", "Id", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.OrderFtps", "EdiId", "dbo.Edis", "Id", cascadeDelete: true);
            AddForeignKey("dbo.DataFtps", "EdiId", "dbo.Edis", "Id", cascadeDelete: true);
        }
    }
}
