namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveHomeAddressColumnFromHelperTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Helper", "HomeAddress");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Helper", "HomeAddress", c => c.String());
        }
    }
}
