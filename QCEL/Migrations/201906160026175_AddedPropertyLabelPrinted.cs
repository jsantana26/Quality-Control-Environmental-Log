namespace QCEL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedPropertyLabelPrinted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EnvironmentalSamples", "LabelPrinted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.EnvironmentalSamples", "LabelPrinted");
        }
    }
}
