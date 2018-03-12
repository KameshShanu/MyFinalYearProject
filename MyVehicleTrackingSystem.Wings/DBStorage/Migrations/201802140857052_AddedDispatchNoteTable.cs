namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDispatchNoteTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DispatchNote",
                c => new
                    {
                        DispatchNoteId = c.Int(nullable: false, identity: true),
                        Driver = c.String(),
                        Helper = c.String(),
                        Client = c.String(),
                        CompanyAddress = c.String(),
                        VehicleLicensePlateNumber = c.String(),
                        Quantity = c.String(),
                        VehicleDeliveryType = c.String(),
                        DispatchDate = c.DateTime(nullable: false),
                        DispatchId = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.DispatchNoteId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DispatchNote");
        }
    }
}
