using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryExtension.Infrastructure;

public class AppDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
{
    public AppDbContextFactory()
    {

    }

    private readonly IConfiguration Configuration;

    public AppDbContextFactory(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public ApplicationDbContext CreateDbContext(string[] args)
    {
        string filePath = @"E:\dev\KursModestProgrammer\LibraryExtension\LibraryExtension.Infrastructure\appsettings.json";
        IConfiguration Configuration = new ConfigurationBuilder()
               .SetBasePath(Path.GetDirectoryName(filePath))
               .AddJsonFile("appSettings.json")
               .Build();

        var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
        optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));

        return new ApplicationDbContext(optionsBuilder.Options);
    }
}
