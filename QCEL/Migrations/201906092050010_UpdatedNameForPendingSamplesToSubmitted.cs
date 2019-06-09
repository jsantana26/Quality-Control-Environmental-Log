namespace QCEL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedNameForPendingSamplesToSubmitted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EnvironmentalSamples", "Submitted", c => c.Boolean(nullable: false));
            DropColumn("dbo.EnvironmentalSamples", "PendingSubmission");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EnvironmentalSamples", "PendingSubmission", c => c.Boolean(nullable: false));
            DropColumn("dbo.EnvironmentalSamples", "Submitted");
        }
    }
}
