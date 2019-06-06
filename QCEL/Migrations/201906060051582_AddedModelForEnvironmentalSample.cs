namespace QCEL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedModelForEnvironmentalSample : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EnvironmentalSamples",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SampleNumber = c.String(),
                        Location = c.String(),
                        MicroTest = c.String(),
                        Type = c.String(),
                        Zone = c.String(),
                        ProductCode = c.String(),
                        RequestType = c.String(),
                        Initials = c.String(),
                        PendingSubmission = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EnvironmentalSamples");
        }
    }
}
