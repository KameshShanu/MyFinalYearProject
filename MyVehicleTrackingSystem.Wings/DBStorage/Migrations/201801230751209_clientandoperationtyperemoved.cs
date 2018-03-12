namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class clientandoperationtyperemoved : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.Client");
            DropTable("dbo.OperationType");
        }
        
        public override void Down()
        {
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
                .PrimaryKey(t => t.OperationTypeId);
            
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
            
        }
    }
}
