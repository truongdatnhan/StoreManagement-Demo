using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace Infrastructure.Persistence
{
    //DataFactory is for this class library can run independence without injecting optionsBuilder from application project
    public class DataFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            var connectionString = @"server=localhost; port=3306; database=store_management; user=root; password=";
            var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
            optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString), options =>
            {
                options.EnableStringComparisonTranslations();
            });
            //optionsBuilder.LogTo(Console.WriteLine);
            return new DataContext(optionsBuilder.Options);
        }
    }
}