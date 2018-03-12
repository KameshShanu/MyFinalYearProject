namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class clientAndOperationTypesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Client",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        CompanyAddress = c.String(),
                        PhoneNumber1 = c.String(),
                        PhoneNumber2 = c.String(),
                        VAT = c.String(),
                        SVAT = c.String(),
                        IsDeleted = c.Boolean(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ClientId);
            
            CreateTable(
                "dbo.OperationType",
                c => new
                    {
                        OperationTypeId = c.Int(nullable: false, identity: true),
                        OperationTypeName = c.String(),
                        ClientRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DriverCommissionRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        PorterCommissionRate = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ClientId = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.OperationTypeId)
                .ForeignKey("dbo.Client", t => t.ClientId, cascadeDelete: true)
                .Index(t => t.ClientId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OperationType", "ClientId", "dbo.Client");
            DropIndex("dbo.OperationType", new[] { "ClientId" });
            DropTable("dbo.OperationType");
            DropTable("dbo.Client");
        }
    }
}
