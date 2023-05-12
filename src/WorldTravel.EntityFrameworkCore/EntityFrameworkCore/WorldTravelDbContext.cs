using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Modeling;
using Volo.Abp.FeatureManagement.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.IdentityServer.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.TenantManagement;
using Volo.Abp.TenantManagement.EntityFrameworkCore;
using Volo.Abp.Users.EntityFrameworkCore;
using WorldTravel.Entities.Cities;
using WorldTravel.Entities.Files;
using WorldTravel.Entities.Logs;
using WorldTravel.Entities.MailTemplates;
using WorldTravel.Entities.MessageContents;
using WorldTravel.Entities.Messages;
using WorldTravel.Entities.SentMails;
using WorldTravel.Entities.Towns;
using WorldTravel.Entities.Users;

namespace WorldTravel.EntityFrameworkCore
{
    [ReplaceDbContext(typeof(IIdentityDbContext))]
    [ReplaceDbContext(typeof(ITenantManagementDbContext))]
    [ConnectionStringName("Default")]
    public class WorldTravelDbContext : 
        AbpDbContext<WorldTravelDbContext>
    {
        /* Add DbSet properties for your Aggregate Roots / Entities here. */
        public DbSet<City> Cities { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<MailTemplate> MailTemplates { get; set; }
        public DbSet<MessageContent> MessageContents { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<SentMail> SentMails { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<AppUser> Users { get; set; }

        public WorldTravelDbContext(DbContextOptions<WorldTravelDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            /* Include modules to your migration db context */

            builder.ConfigurePermissionManagement();
            builder.ConfigureSettingManagement();
            builder.ConfigureBackgroundJobs();
            builder.ConfigureAuditLogging();
            builder.ConfigureIdentity();
            builder.ConfigureIdentityServer();
            builder.ConfigureFeatureManagement();
            builder.ConfigureTenantManagement();

            /* Configure your own tables/entities inside here */

            //builder.Entity<YourEntity>(b =>
            //{
            //    b.ToTable(WorldTravelConsts.DbTablePrefix + "YourEntities", WorldTravelConsts.DbSchema);
            //    b.ConfigureByConvention(); //auto configure for the base class props
            //    //...
            //});

            //TODOO 3
            builder.Entity<AppUser>(b =>
            {
                b.ToTable(AbpIdentityDbProperties.DbTablePrefix + "Users");
                b.ConfigureByConvention();
                b.ConfigureAbpUser();
                b.Property(a => a.UserType).HasColumnName("UserType").HasColumnType("int");
                b.Property(a => a.Gender).HasColumnName("Gender").HasColumnType("int");
                b.Property(a => a.Status).HasColumnName("Status").HasColumnType("int");
                b.Property(a => a.BirthDate).HasColumnName("BirthDate").HasColumnType("datetime");
                b.Property(a => a.ImageId).HasColumnName("ImageId").HasColumnType("int");
                b.HasOne<IdentityUser>().WithOne().HasForeignKey<AppUser>(x => x.Id);
            });
        }
    }
}
