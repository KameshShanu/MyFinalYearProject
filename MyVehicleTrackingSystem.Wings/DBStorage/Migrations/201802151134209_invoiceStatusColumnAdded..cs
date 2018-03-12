namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class invoiceStatusColumnAdded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Invoice", "InvoiceType", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Invoice", "InvoiceType");
        }
    }
}
