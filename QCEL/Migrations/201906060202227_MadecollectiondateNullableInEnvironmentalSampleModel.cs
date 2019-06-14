namespace QCEL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MadecollectiondateNullableInEnvironmentalSampleModel : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Samples", "CollectionDate", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Samples", "CollectionDate", c => c.DateTime(nullable: false));
        }
    }
}
