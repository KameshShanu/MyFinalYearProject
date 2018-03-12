namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveFieldsFromDriverTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Driver", "EmpNumber");
            DropColumn("dbo.Driver", "Email");
            DropColumn("dbo.Driver", "PixURL");
            DropColumn("dbo.Driver", "PhoneNumber3");
            DropColumn("dbo.Driver", "EmpStatus");
            DropColumn("dbo.Driver", "MaritalStatus");
            DropColumn("dbo.Driver", "TripId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Driver", "TripId", c => c.Int(nullable: false));
            AddColumn("dbo.Driver", "MaritalStatus", c => c.Int(nullable: false));
            AddColumn("dbo.Driver", "EmpStatus", c => c.Int(nullable: false));
            AddColumn("dbo.Driver", "PhoneNumber3", c => c.String());
            AddColumn("dbo.Driver", "PixURL", c => c.String());
            AddColumn("dbo.Driver", "Email", c => c.String());
            AddColumn("dbo.Driver", "EmpNumber", c => c.String());
        }
    }
}
