namespace DevDay.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdMessage = c.Guid(),
                        IdPerson = c.Guid(nullable: false),
                        IdRetro = c.Guid(nullable: false),
                        Message = c.String(nullable: false, maxLength: 255),
                        Date = c.DateTime(nullable: false),
                        MessageType = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Retros", t => t.IdRetro)
                .Index(t => t.IdRetro);
            
            CreateTable(
                "dbo.Persons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdPerson = c.Guid(nullable: false),
                        IdRetro = c.Guid(nullable: false),
                        IdMessage = c.Guid(),
                        Name = c.String(),
                        Retro_IdRetro = c.Guid(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Messages", t => t.Id)
                .ForeignKey("dbo.Retros", t => t.Retro_IdRetro)
                .Index(t => t.Id)
                .Index(t => t.Retro_IdRetro);
            
            CreateTable(
                "dbo.Retros",
                c => new
                    {
                        IdRetro = c.Guid(nullable: false),
                        IdPerson = c.Guid(nullable: false),
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.IdRetro);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Messages", "IdRetro", "dbo.Retros");
            DropForeignKey("dbo.Persons", "Retro_IdRetro", "dbo.Retros");
            DropForeignKey("dbo.Persons", "Id", "dbo.Messages");
            DropIndex("dbo.Persons", new[] { "Retro_IdRetro" });
            DropIndex("dbo.Persons", new[] { "Id" });
            DropIndex("dbo.Messages", new[] { "IdRetro" });
            DropTable("dbo.Retros");
            DropTable("dbo.Persons");
            DropTable("dbo.Messages");
        }
    }
}
