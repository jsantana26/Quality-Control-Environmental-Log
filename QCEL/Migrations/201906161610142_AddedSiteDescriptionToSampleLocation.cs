namespace QCEL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedSiteDescriptionToSampleLocation : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.SampleLocations", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.SampleLocations", "Description");
        }
    }
}
