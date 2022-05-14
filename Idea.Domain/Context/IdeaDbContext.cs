

using Idea.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Idea.Domain.Context
{
    public partial class IdeaDbContext : IdentityDbContext
    {
        public IdeaDbContext(DbContextOptions<IdeaDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<EmailTemplates> EmailTemplates { get; set; }
        public virtual DbSet<UserTypes> UserTypes { get; set; }
        public virtual DbSet<OperatorSettings> OperatorSettings { get; set; }

        public virtual DbSet<RejectionReasons> RejectionReasons { get; set; }
        public virtual DbSet<PublicationRejectionReasons> PublicationRejectionReasons { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                //    .AddJsonFile(@Directory.GetCurrentDirectory() + "/../RealEstate.API/appsettings.json").Build();

                IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))
                    .AddJsonFile(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/../RealEstate.API/appsettings.json").Build();

                var connectionString = configuration.GetConnectionString("RealEstateDBConnection");

                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}