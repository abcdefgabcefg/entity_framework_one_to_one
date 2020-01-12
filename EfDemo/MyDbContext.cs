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
    }
}
