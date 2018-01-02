using System;
using System.IO;
using Microsoft.Extensions;
using Microsoft.Extensions.Configuration;
using ToDo.EfRepository;
using Microsoft.EntityFrameworkCore;

namespace ToDo.TestConsole
{
    class Program
    {
       
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            ToDoDbContext myRepository = aasdf();

            foreach (Models.ToDo item in myRepository.ToDos)
            {
                Console.WriteLine(item.Description);
            }

            Console.WriteLine("Bye World!");


            Console.ReadLine();
        }

        private static ToDoDbContext aasdf()
        {
            var builder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);

            IConfigurationRoot configuration = builder.Build();
            string connString = configuration.GetConnectionString("DefaultConnection");

            var optionsBuilder = new DbContextOptionsBuilder<ToDoDbContext>();
            optionsBuilder.UseSqlServer(connString);

            ToDoDbContext myRepository = new EfRepository.ToDoDbContext(optionsBuilder.Options);
            return myRepository;
        }

       
    }
}
