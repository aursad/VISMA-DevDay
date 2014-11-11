namespace DevDay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1Mi3 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Persons", new[] { "Message_Id" });
            DropColumn("dbo.Messages", "IdPerson");
            RenameColumn(table: "dbo.Messages", name: "Message_Id", newName: "IdPerson");
            CreateIndex("dbo.Messages", "IdPerson");
            DropColumn("dbo.Persons", "Message_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Persons", "Message_Id", c => c.Int(nullable: false));
            DropIndex("dbo.Messages", new[] { "IdPerson" });
            RenameColumn(table: "dbo.Messages", name: "IdPerson", newName: "Message_Id");
            AddColumn("dbo.Messages", "IdPerson", c => c.Guid(nullable: false));
            CreateIndex("dbo.Persons", "Message_Id");
        }
    }
}
