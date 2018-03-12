namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveGoodsTypeFromVehcileTable : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Vehicle", "GoodsType");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Vehicle", "GoodsType", c => c.String());
        }
    }
}
