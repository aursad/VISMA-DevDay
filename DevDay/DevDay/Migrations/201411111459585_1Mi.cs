namespace DevDay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1Mi : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Retros", "IdPerson", c => c.Guid());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Retros", "IdPerson", c => c.Guid(nullable: false));
        }
    }
}
