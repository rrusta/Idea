using Idea.Domain.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Idea.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Application Layer 
            //services.AddScoped<IBillsService, BillsService>();

            //Infrastructure.Data Layer
            //services.AddScoped<IBillsRepository, BillsRepository>();

            //Generic
            //services.AddScoped<IGenericRepository<Bill>, GenericRepository<Bill>>();

            //IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))
            //        .AddJsonFile(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/appsettings.json").Build();
            //var connectionString = configuration.GetConnectionString("Server=DESKTOP-VDAB9TK\\SQLEXPRESS;Database=IdeaDb;Trusted_Connection=True;MultipleActiveResultSets=true;");

            services.AddDbContext<IdeaDbContext>(options =>
                {
                    options.UseSqlServer("Server=DESKTOP-12BHAVL;Database=IdeaDb;Trusted_Connection=True;MultipleActiveResultSets=true;");
                });

        }
    }
}