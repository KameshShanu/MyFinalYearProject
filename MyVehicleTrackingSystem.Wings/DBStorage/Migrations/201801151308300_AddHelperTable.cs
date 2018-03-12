namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddHelperTable : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Helper",
                c => new
                    {
                        HelperId = c.Int(nullable: false, identity: true),
                        HelperFirstName = c.String(),
                        HelperLastName = c.String(),
                        NIC = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        HomeAddress = c.String(),
                        ResidentAddress = c.String(),
                        PhoneNumber1 = c.String(),
                        PhoneNumber2 = c.String(),
                        EPFNumber = c.String(),
                        StartDateOfWork = c.DateTime(nullable: false),
                        PeriodOfService = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        IsAvailable = c.Boolean(nullable: false),
                        Created = c.DateTime(nullable: false),
                        Modified = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.HelperId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Helper");
        }
    }
}
