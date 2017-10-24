namespace Evaluacion2WebApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class presosMigracion : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Condenas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaInicioCondena = c.DateTime(nullable: false),
                        FechaCondena = c.DateTime(nullable: false),
                        PresoId = c.Int(),
                        JuezId = c.Int(),
                        Delito_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Delitoes", t => t.Delito_Id)
                .ForeignKey("dbo.Presoes", t => t.PresoId)
                .Index(t => t.PresoId)
                .Index(t => t.Delito_Id);
            
            CreateTable(
                "dbo.Delitoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        CondenaMinima = c.Int(nullable: false),
                        CondenaMaxima = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Juezs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Rut = c.String(),
                        Sexo = c.Boolean(nullable: false),
                        Domicilio = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Presoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Rut = c.String(),
                        Nombre = c.String(),
                        FechaNacimiento = c.DateTime(nullable: false),
                        Domicilio = c.String(),
                        Sexo = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Condenas", "PresoId", "dbo.Presoes");
            DropForeignKey("dbo.Condenas", "Delito_Id", "dbo.Delitoes");
            DropIndex("dbo.Condenas", new[] { "Delito_Id" });
            DropIndex("dbo.Condenas", new[] { "PresoId" });
            DropTable("dbo.Presoes");
            DropTable("dbo.Juezs");
            DropTable("dbo.Delitoes");
            DropTable("dbo.Condenas");
        }
    }
}
