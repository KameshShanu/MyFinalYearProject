namespace DBStorage.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedIsDispatchNoteReceivedAndIsGoodsDeliveredAndRemarksColoumnsToDispatchTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.DispatchNote", "IsDispatchNoteReceived", c => c.Boolean(nullable: false));
            AddColumn("dbo.DispatchNote", "IsGoodsDelivered", c => c.Boolean(nullable: false));
            AddColumn("dbo.DispatchNote", "Remarks", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.DispatchNote", "Remarks");
            DropColumn("dbo.DispatchNote", "IsGoodsDelivered");
            DropColumn("dbo.DispatchNote", "IsDispatchNoteReceived");
        }
    }
}
