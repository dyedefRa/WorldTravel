using Microsoft.EntityFrameworkCore;
using Volo.Abp;
using WorldTravel.Entities.Cities;
using WorldTravel.Entities.Countries;
using WorldTravel.Entities.CountryContentFiles;
using WorldTravel.Entities.CountryContents;
using WorldTravel.Entities.Files;
using WorldTravel.Entities.Forms;
using WorldTravel.Entities.Logs;
using WorldTravel.Entities.MailTemplates;
using WorldTravel.Entities.SentMails;
using WorldTravel.Entities.ShareContentFiles;
using WorldTravel.Entities.ShareContents;
using WorldTravel.Entities.Towns;

namespace WorldTravel.EntityFrameworkCore
{
    public static class CustomDbContextModelCreatingExtensions
    {
        public static void CustomConfigure(this ModelBuilder modelBuilder)
        {
            Check.NotNull(modelBuilder, nameof(modelBuilder));

            var dbTablePrefix = WorldTravelConsts.DbTablePrefix;

            modelBuilder.Entity<City>(entity =>
            {
                entity.ToTable(dbTablePrefix + "Cities");

                entity.Property(e => e.Title).IsRequired(true).HasMaxLength(255);
                entity.Property(e => e.CityNo).HasColumnType("int");
                entity.Property(e => e.AreaNumber).IsRequired(true).HasMaxLength(255);
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.ToTable(dbTablePrefix + "Countries");

                entity.Property(e => e.Title).IsRequired(true).HasMaxLength(255);
            });

            modelBuilder.Entity<CountryContentFile>(entity =>
            {
                entity.ToTable(dbTablePrefix + "CountryContentFiles");

                entity.Property(e => e.CountryContentId).HasColumnType("int");
                entity.Property(e => e.FileId).HasColumnType("int");

                entity.HasIndex(e => e.CountryContentId, "IX_AppCountryContentFile_CountryContentId");
                entity.HasIndex(e => e.FileId, "IX_AppCountryContentFile_FileId");

                entity.HasOne(d => d.CountryContent)
                 .WithMany(p => p.CountryContentFiles)
                 .HasForeignKey(d => d.CountryContentId)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .HasConstraintName("FK_AppCountryContentFiles_AppCountryContents");

                entity.HasOne(d => d.File)
                 .WithMany(p => p.CountryContentFiles)
                 .HasForeignKey(d => d.FileId)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .HasConstraintName("FK_AppCountryContentFiles_AppFiles");
            });

            modelBuilder.Entity<CountryContent>(entity =>
            {
                entity.ToTable(dbTablePrefix + "CountryContents");

                entity.Property(e => e.Title).IsRequired(true).HasMaxLength(255);
                entity.Property(e => e.Description).IsRequired(true);
                entity.Property(e => e.CountryId).HasColumnType("int");
                entity.Property(e => e.ReadCount).HasColumnType("int");
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.ValidDate).HasColumnType("datetime");
                entity.Property(a => a.Status).HasColumnType("int");

                entity.HasIndex(e => e.CountryId, "IX_AppCountryContent_CountryId");

                entity.HasOne(d => d.Country)
                 .WithMany(p => p.CountryContents)
                 .HasForeignKey(d => d.CountryId)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .HasConstraintName("FK_AppCountryContents_AppCountries");
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.ToTable(dbTablePrefix + "Files");

                entity.Property(e => e.Name).IsRequired(true).HasMaxLength(500);
                entity.Property(e => e.Path).IsRequired(true).HasMaxLength(500);
                entity.Property(e => e.FullPath).IsRequired(true).HasMaxLength(500);
                entity.Property(a => a.FileType).HasColumnType("int");
                entity.Property(a => a.Rank).HasColumnType("int");
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(a => a.Status).HasColumnType("int");
            });

            modelBuilder.Entity<Form>(entity =>
            {
                entity.ToTable(dbTablePrefix + "Forms");

                entity.Property(e => e.Name).IsRequired(true).HasMaxLength(100);
                entity.Property(e => e.Surname).IsRequired(true).HasMaxLength(100);
                entity.Property(e => e.Email).IsRequired(true).HasMaxLength(100);
                entity.Property(e => e.PhoneNumber).IsRequired(true).HasMaxLength(100);
                entity.Property(e => e.Description).IsRequired(false);
                entity.Property(a => a.Gender).HasColumnType("int");
                entity.Property(e => e.BirthDate).HasColumnType("datetime");
                entity.Property(e => e.CountryId).HasColumnType("int");
                entity.Property(e => e.IsContacted).HasColumnType("bit");
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(a => a.Status).HasColumnType("int");

                entity.HasIndex(e => e.CountryId, "IX_AppForm_CountryId");

                entity.HasOne(d => d.Country)
               .WithMany(p => p.Forms)
               .HasForeignKey(d => d.CountryId)
               .OnDelete(DeleteBehavior.ClientSetNull)
               .HasConstraintName("FK_AppForms_AppCountries");
            });

            modelBuilder.Entity<Log>(entity =>
            {
                entity.ToTable(dbTablePrefix + "Logs");

                entity.Property(e => e.Message);
                entity.Property(e => e.MessageTemplate);
                entity.Property(e => e.Level).HasMaxLength(500);
                entity.Property(e => e.TimeStamp).HasColumnType("datetime");
                entity.Property(e => e.Exception);
                entity.Property(e => e.Properties);
            });

            modelBuilder.Entity<MailTemplate>(entity =>
            {
                entity.ToTable(dbTablePrefix + "MailTemplates");

                entity.Property(e => e.Subject).IsRequired(true).HasMaxLength(500);
                entity.Property(e => e.MailKey).IsRequired(true).HasMaxLength(100);
                entity.Property(e => e.MailTemplateValue).IsRequired(true);
                entity.Property(e => e.InsertedDate).HasColumnType("datetime");
                entity.Property(a => a.Status).HasColumnType("int");
            });

            modelBuilder.Entity<SentMail>(entity =>
            {
                entity.ToTable(dbTablePrefix + "SentMail");

                entity.Property(e => e.ToAddress).IsRequired(false).HasMaxLength(500);
                entity.Property(e => e.CcAddress).IsRequired(false).HasMaxLength(500);
                entity.Property(e => e.BccAddress).IsRequired(false).HasMaxLength(500);
                entity.Property(e => e.Subject).IsRequired(true);
                entity.Property(e => e.Body).IsRequired(true);
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ShareContentFile>(entity =>
            {
                entity.ToTable(dbTablePrefix + "ShareContentFiles");

                entity.Property(e => e.ShareContentId).HasColumnType("int");
                entity.Property(e => e.FileId).HasColumnType("int");

                entity.HasIndex(e => e.ShareContentId, "IX_AppShareContentFile_ShareContentId");
                entity.HasIndex(e => e.FileId, "IX_AppShareContentFile_FileId");

                entity.HasOne(d => d.ShareContent)
                 .WithMany(p => p.ShareContentFiles)
                 .HasForeignKey(d => d.ShareContentId)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .HasConstraintName("FK_AppShareContentFiles_AppShareContents");

                entity.HasOne(d => d.File)
                 .WithMany(p => p.ShareContentFiles)
                 .HasForeignKey(d => d.FileId)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .HasConstraintName("FK_AppShareContentFiles_AppFiles");
            });

            modelBuilder.Entity<ShareContent>(entity =>
            {
                entity.ToTable(dbTablePrefix + "ShareContents");

                entity.Property(e => e.Title).IsRequired(true).HasMaxLength(255);
                entity.Property(e => e.Description).IsRequired(false);
                entity.Property(e => e.CountryId).HasColumnType("int");
                entity.Property(e => e.ReadCount).HasColumnType("int");
                entity.Property(e => e.CreatedDate).HasColumnType("datetime");
                entity.Property(e => e.ValidDate).HasColumnType("datetime");
                entity.Property(a => a.Status).HasColumnType("int");

                entity.HasIndex(e => e.CountryId, "IX_AppShareContent_CountryId");

                entity.HasOne(d => d.Country)
                 .WithMany(p => p.ShareContents)
                 .HasForeignKey(d => d.CountryId)
                 .OnDelete(DeleteBehavior.ClientSetNull)
                 .HasConstraintName("FK_AppShareContents_AppCountries");
            });

            modelBuilder.Entity<Town>(entity =>
            {
                entity.ToTable(WorldTravelConsts.DbTablePrefix + "Towns");

                entity.Property(e => e.Title).IsRequired(true).HasMaxLength(255);

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Towns)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AppTowns_AppCities");
            });

        }
    }
}
