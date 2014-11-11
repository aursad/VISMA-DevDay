namespace DevDay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _1Mi2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Persons", "Id", "dbo.Messages");
            DropIndex("dbo.Persons", new[] { "Id" });
            DropColumn("dbo.Persons", "IdPerson");
            RenameColumn(table: "dbo.Persons", name: "Retro_IdRetro", newName: "IdPerson");
            RenameIndex(table: "dbo.Persons", name: "IX_Retro_IdRetro", newName: "IX_IdPerson");
            DropPrimaryKey("dbo.Persons");
            AddColumn("dbo.Persons", "Message_Id", c => c.Int(nullable: false));
            AddPrimaryKey("dbo.Persons", "IdPerson");
            CreateIndex("dbo.Persons", "Message_Id");
            AddForeignKey("dbo.Persons", "Message_Id", "dbo.Messages", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Persons", "Message_Id", "dbo.Messages");
            DropIndex("dbo.Persons", new[] { "Message_Id" });
            DropPrimaryKey("dbo.Persons");
            DropColumn("dbo.Persons", "Message_Id");
            AddPrimaryKey("dbo.Persons", "Id");
            RenameIndex(table: "dbo.Persons", name: "IX_IdPerson", newName: "IX_Retro_IdRetro");
            RenameColumn(table: "dbo.Persons", name: "IdPerson", newName: "Retro_IdRetro");
            AddColumn("dbo.Persons", "IdPerson", c => c.Guid(nullable: false));
            CreateIndex("dbo.Persons", "Id");
            AddForeignKey("dbo.Persons", "Id", "dbo.Messages", "Id");
        }
    }
}
