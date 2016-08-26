namespace DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class update1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Category", "TransactionDate", c => c.DateTime(nullable: false));
            AddColumn("dbo.Product", "TransactionDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Product", "TransactionDate");
            DropColumn("dbo.Category", "TransactionDate");
        }
    }
}
