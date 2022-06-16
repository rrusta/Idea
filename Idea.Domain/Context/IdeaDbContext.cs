

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
        public virtual DbSet<AttachmentsMetaData> AttachmentsMetaData { get; set; }
        public virtual DbSet<AttachmentTypes> AttachmentTypes { get; set; }
        public virtual DbSet<DistancesFromLocationRange> DistancesFromLocationRange { get; set; }
        public virtual DbSet<Districts> Districts { get; set; }
        public virtual DbSet<EmailTemplates> EmailTemplates { get; set; }
        public virtual DbSet<FavoritePublications> FavoritePublications { get; set; }
        public virtual DbSet<OperatorSettings> OperatorSettings { get; set; }
        public virtual DbSet<PhonePrefixes> PhonePrefixes { get; set; }
        public virtual DbSet<PublicationMainCategories> PublicationMainCategories { get; set; }
        public virtual DbSet<PublicationCategories> PublicationCategories { get; set; }
        public virtual DbSet<Publications> Publications { get; set; }
        public virtual DbSet<PublicationTypes> PublicationTypes { get; set; }
        public virtual DbSet<PublicationStatuses> PublicationStatuses { get; set; }
        public virtual DbSet<PublicationStates> PublicationStates { get; set; }
        public virtual DbSet<PublisherTypes> PublisherTypes { get; set; }
        public virtual DbSet<PublicationPublishedRange> PublicationPublishedRange { get; set; }
        public virtual DbSet<QuadraturesRange> QuadraturesRange { get; set; }
        public virtual DbSet<RejectionReasons> RejectionReasons { get; set; }
        public virtual DbSet<PublicationRejectionReasons> PublicationRejectionReasons { get; set; }
        public virtual DbSet<PublicationCategoriesProperties> PublicationCategoriesProperties { get; set; }
        public virtual DbSet<PriceSearchFilters> PriceSearchFilters { get; set; }
        public virtual DbSet<RoomsNumberSearchFilters> RoomsNumberSearchFilters { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }
        public virtual DbSet<SortOrder> SortOrder { get; set; }
        public virtual DbSet<Towns> Towns { get; set; }
        public virtual DbSet<Units> Units { get; set; }
        public virtual DbSet<UnitTypes> UnitTypes { get; set; }
        public virtual DbSet<UserTypes> UserTypes { get; set; }
        public virtual DbSet<WatchedPublications> WatchedPublications { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory())
                //    .AddJsonFile(@Directory.GetCurrentDirectory() + "/../RealEstate.API/appsettings.json").Build();

                IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location))
                    .AddJsonFile(Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/../Idea.API/appsettings.json").Build();

                var connectionString = configuration.GetConnectionString("IdeaDBConnection");

                optionsBuilder.UseSqlServer(connectionString);
            }
        }
    }
}