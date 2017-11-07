namespace Evaluacion2WebApi.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Evaluacion2WebApi.Models.PresosDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(Evaluacion2WebApi.Models.PresosDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            context.Delitos.AddOrUpdate(
                new Models.Delito { Id = 1 , Nombre = "Homicidio" , CondenaMinima = 5 , CondenaMaxima = 20 },
                new Models.Delito { Id = 1, Nombre = "Femicidio", CondenaMinima = 5, CondenaMaxima = 20 },
                new Models.Delito { Id = 1, Nombre = "Robo con Intimidacion", CondenaMinima = 1, CondenaMaxima = 12 },
                new Models.Delito { Id = 1, Nombre = "Robo en lugar no habitado", CondenaMinima = 1, CondenaMaxima = 5 },
                new Models.Delito { Id = 1, Nombre = "Cohecho", CondenaMinima = 5, CondenaMaxima = 8 }
                );
        }
    }
}
