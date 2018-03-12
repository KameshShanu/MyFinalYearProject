namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsPrintedColoumnToDispatchTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DispatchNote", "IsPrinted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.DispatchNote", "IsPrinted");
        }
    }
}
