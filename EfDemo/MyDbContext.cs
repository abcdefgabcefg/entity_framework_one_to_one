using EfDemo.Models;
using System.Data.Entity;

namespace EfDemo
{
    public class MyDbContext : DbContext
    {
        public DbSet<TableWithPrincipalKey> TableWithPrincipalKey { get; set; }

        public DbSet<TableWithForeignKey1> TableWithForeignKey1 { get; set; }

        public DbSet<TableWithForeignKey2> TableWithForeignKey2 { get; set; }

        public MyDbContext() : base("Server=.;Database=MyDatabase;Integrated Security=True;") { }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<TableWithForeignKey1>()
                .HasRequired(tableWithForeignKey1 => tableWithForeignKey1.TableWithPrincipalKey)
                .WithRequiredDependent(tableWithPrincipalKey => tableWithPrincipalKey.TableWithForeignKey1);

            modelBuilder
                .Entity<TableWithForeignKey2>()
                .HasRequired(tableWithForeignKey1 => tableWithForeignKey1.TableWithPrincipalKey)
                .WithRequiredDependent(tableWithPrincipalKey => tableWithPrincipalKey.TableWithForeignKey2);

            base.OnModelCreating(modelBuilder);
        }
    }
}
