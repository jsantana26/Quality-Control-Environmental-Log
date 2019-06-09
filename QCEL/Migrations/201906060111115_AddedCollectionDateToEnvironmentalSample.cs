namespace QCEL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedCollectionDateToEnvironmentalSample : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EnvironmentalSamples", "CollectionDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EnvironmentalSamples", "Submitted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EnvironmentalSamples", "Submitted", c => c.String());
            DropColumn("dbo.EnvironmentalSamples", "CollectionDate");
        }
    }
}
