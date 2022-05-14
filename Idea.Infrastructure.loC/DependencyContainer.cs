using Amazon.S3;
using Idea.Application.Interfaces;
using Idea.Domain.Context;
using Idea.Domain.IdentityModels;
using Idea.Infrastructure.Data.Helpers;
using Idea.Infrastructure.Data.Interfaces;
using Idea.Infrastructure.Data.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Idea.Application.Interfaces;
using RealEstate.Infrastructure.Data.Repositories;
using System.Reflection;
using Idea.Application.Services;
using RealEstate.Application.Services;

namespace Idea.Infrastructure.IoC
{
    public class DependencyContainer
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Application Layer 
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IEmailTemplatesService, EmailTemplatesService>();
            services.AddScoped<ISettingsService, SettingsService>();

            //Infrastructure.Data Layer
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<ISendEmailRepository, SendEmailRepository>();
            services.AddScoped<ISettingsRepository, SettingsRepository>();
            services.AddScoped<IOperatorSettingsRepository, OperatorSettingsRepository>();
            services.AddScoped<IEmailTemplatesRepository, EmailTemplatesRepository>();
            services.AddScoped<IAWSS3Repository, AWSS3Repository>();






            IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))
                    .AddJsonFile(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/appsettings.json").Build();
            var connectionString = configuration.GetConnectionString(DataConstants.AppSettings.ConnectionString);

            services.AddDbContext<IdeaDbContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            services.Configure<CloudinarySettings>(configuration.GetSection("CloudinarySettings"));
            services.Configure<AWSSettings>(configuration.GetSection("AWSSettings"));

            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = false;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
            .AddEntityFrameworkStores<IdeaDbContext>()
            .AddDefaultTokenProviders();

            //services.AddAWSService<IAmazonS3>();
        }
    }
}
