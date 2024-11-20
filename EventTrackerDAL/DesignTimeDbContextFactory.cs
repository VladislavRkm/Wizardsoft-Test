using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace EventTrackerDAL
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<EventTrackerContext>
    {
        public EventTrackerContext CreateDbContext(string[] args)
        {
            string rootProjectPath = Path.Combine(Directory.GetCurrentDirectory(), @"..\EventTrackerSystem");
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(rootProjectPath)
                .AddJsonFile("appsettings.json")
                .Build();

            var connectionString = configuration.GetConnectionString("EventTrackerContext");

            var optionsBuilder = new DbContextOptionsBuilder<EventTrackerContext>();
            optionsBuilder.UseNpgsql(connectionString);

            return new EventTrackerContext(optionsBuilder.Options);
        }
    }
}