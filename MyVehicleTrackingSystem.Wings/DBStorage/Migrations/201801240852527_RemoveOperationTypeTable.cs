namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveOperationTypeTable : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OperationType", "ClientId", "dbo.Client");
            DropIndex("dbo.OperationType", new[] { "ClientId" });
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
            
            CreateIndex("dbo.OperationType", "ClientId");
            AddForeignKey("dbo.OperationType", "ClientId", "dbo.Client", "ClientId", cascadeDelete: true);
        }
    }
}
