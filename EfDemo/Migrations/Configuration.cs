namespace EfDemo.Migrations
{
    using EfDemo.Models;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<MyDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(MyDbContext context)
        {
            var tableWithPrincipalKeyEntities = new[] 
            {
                new TableWithPrincipalKey
                {
                    Id = 1,
                },
                new TableWithPrincipalKey
                {
                    Id = 2
                },
                new TableWithPrincipalKey
                {
                    Id = 3
                },
                new TableWithPrincipalKey
                {
                    Id = 4
                }
            };

            var tableWithForeignKey1Entities = new[]
            {
                new TableWithForeignKey1
                {
                    Id = 1,
                },
                new TableWithForeignKey1
                {
                    Id = 2,
                }
            };

            var tableWithForeignKey2Entities = new[]
            {
                new TableWithForeignKey2
                {
                    Id = 1,
                },
                new TableWithForeignKey2
                {
                    Id = 3,
                }
            };

            context
                .Set<TableWithPrincipalKey>()
                .AddOrUpdate(tableWithPrincipalKeyEntities);

            context.SaveChanges();

            context
                .Set<TableWithForeignKey1>()
                .AddOrUpdate(tableWithForeignKey1Entities);

            context
                .Set<TableWithForeignKey2>()
                .AddOrUpdate(tableWithForeignKey2Entities);

            context.SaveChanges();
        }
    }
}
