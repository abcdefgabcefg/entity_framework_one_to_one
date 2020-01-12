using EfDemo.Models;
using System;
using System.Data.Entity;
using System.Linq;

namespace EfDemo
{
    public static class Program
    {
        public static void Main()
        {
            using (var context = new MyDbContext())
            {
                Print(context.TableWithForeignKey1, $"{nameof(TableWithForeignKey1)}");

                Print(context.TableWithForeignKey2, $"{nameof(TableWithForeignKey2)}");

                Print(context.TableWithPrincipalKey, $"{nameof(TableWithPrincipalKey)}");
            }
        }

        private static void Print<T>(DbSet<T> entities, string message) where T : class
        {
            Console.WriteLine(message);

            var entitiesList = entities.ToList();

            foreach (var entity in entitiesList)
            {
                Console.WriteLine($"\t{entity}");
            }
        }
    }
}
