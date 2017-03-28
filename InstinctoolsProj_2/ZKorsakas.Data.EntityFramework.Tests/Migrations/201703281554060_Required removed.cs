namespace ZKorsakas.Data.EntityFramework.Tests.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Requiredremoved : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Human", "Name", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Human", "Name", c => c.String(nullable: false));
        }
    }
}
