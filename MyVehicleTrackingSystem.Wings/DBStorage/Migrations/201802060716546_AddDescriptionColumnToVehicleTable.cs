namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddDescriptionColumnToVehicleTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Vehicle", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Vehicle", "Description");
        }
    }
}
