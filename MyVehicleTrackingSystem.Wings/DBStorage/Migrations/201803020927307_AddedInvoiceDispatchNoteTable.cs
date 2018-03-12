namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedInvoiceDispatchNoteTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.InvoiceDispatchNote",
                c => new
                    {
                        InvoiceDispatchNoteId = c.Int(nullable: false, identity: true),
                        DispatchNoteId = c.Int(nullable: false),
                        InvoiceId = c.Int(nullable: false),
                        Driver = c.String(),
                        Helper = c.String(),
                        Client = c.String(),
                        CompanyAddress = c.String(),
                        VehicleLicensePlateNumber = c.String(),
                        Quantity = c.String(),
                        VehicleDeliveryType = c.String(),
                        DispatchDate = c.DateTime(nullable: false),
                        Status = c.String(),
                        DispatchId = c.String(),
                        ClientRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DriverCommissionRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PorterCommissionRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsDispatchNoteReceived = c.Boolean(nullable: false),
                        IsGoodsDelivered = c.Boolean(nullable: false),
                        Remarks = c.String(),
                        IsPrinted = c.Boolean(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceDispatchNoteId)
                .ForeignKey("dbo.Invoice", t => t.InvoiceId, cascadeDelete: true)
                .Index(t => t.InvoiceId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.InvoiceDispatchNote", "InvoiceId", "dbo.Invoice");
            DropIndex("dbo.InvoiceDispatchNote", new[] { "InvoiceId" });
            DropTable("dbo.InvoiceDispatchNote");
        }
    }
}
