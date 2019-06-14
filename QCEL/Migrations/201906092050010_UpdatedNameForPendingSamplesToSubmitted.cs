namespace QCEL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedNameForPendingSamplesToSubmitted : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Samples", "Submitted", c => c.Boolean(nullable: false));
            DropColumn("dbo.Samples", "PendingSubmission");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Samples", "PendingSubmission", c => c.Boolean(nullable: false));
            DropColumn("dbo.Samples", "Submitted");
        }
    }
}
