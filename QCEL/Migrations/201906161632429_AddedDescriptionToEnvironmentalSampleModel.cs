namespace QCEL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedDescriptionToEnvironmentalSampleModel : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EnvironmentalSamples", "Description", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.EnvironmentalSamples", "Description");
        }
    }
}
