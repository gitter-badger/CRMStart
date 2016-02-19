namespace CRMStart.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveMapping : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Edis", "Id", "dbo.Customers");
            AddForeignKey("dbo.Edis", "Id", "dbo.Customers", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Edis", "Id", "dbo.Customers");
            AddForeignKey("dbo.Edis", "Id", "dbo.Customers", "Id");
        }
    }
}
