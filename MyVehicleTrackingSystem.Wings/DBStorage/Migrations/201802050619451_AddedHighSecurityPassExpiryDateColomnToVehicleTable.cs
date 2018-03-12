namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedHighSecurityPassExpiryDateColomnToVehicleTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicle", "HighSecurityPassExpiryDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicle", "HighSecurityPassExpiryDate");
        }
    }
}
