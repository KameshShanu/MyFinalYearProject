namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedStatusColumnToDispathNoteTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DispatchNote", "Status", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DispatchNote", "Status");
        }
    }
}
