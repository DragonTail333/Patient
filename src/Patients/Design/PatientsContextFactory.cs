using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using Patients.Services;

namespace Patients.Design;

public class PatientsContextFactory : IDesignTimeDbContextFactory<PatientsContext>
{
    public PatientsContext CreateDbContext(string[] args)
    {
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false)
            .AddUserSecrets<PatientsContextFactory>(optional: true)
            .Build();

        var optionsBuilder = new DbContextOptionsBuilder<PatientsContext>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        optionsBuilder.UseNpgsql(connectionString);

        return new PatientsContext(optionsBuilder.Options);
    }
}