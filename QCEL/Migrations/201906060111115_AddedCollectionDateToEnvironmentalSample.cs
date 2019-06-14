namespace QCEL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCollectionDateToEnvironmentalSample : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Samples", "CollectionDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Samples", "Submitted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Samples", "Submitted", c => c.String());
            DropColumn("dbo.Samples", "CollectionDate");
        }
    }
}
