using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Personal.Domain;

namespace Personal.Db
{
    class Program
    {
        static void Main(string[] args)
        {
            var dataContextFactory = new DataContextFactory();
            var dataContext = dataContextFactory.CreateDbContext(new string[] {});
//            var dataSeeder = new DataSeeder(dataContextFactory.Container, dataContext);

            if (args.Any(_ => _ == "--migrate"))
            {
                Console.WriteLine("Applying migrations");
                dataContext.Database.Migrate();
            }
//            else
//            {
//                if (args.Length > 0)
//                {
//                    foreach (var seedClassname in args)
//                    {
//                        dataSeeder.ApplySeedData(seedClassname);
//                    }
//                }
//                else
//                {
//                    dataSeeder.ApplySeedData();
//                }
//            }
        }
    }
}