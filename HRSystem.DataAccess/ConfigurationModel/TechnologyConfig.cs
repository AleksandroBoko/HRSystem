using HRSystem.DataAccess.Entity;
using System.Data.Entity;

namespace HRSystem.DataAccess.ConfigurationModel
{
    public static class TechnologyConfig
    {
        public static void Configure(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Technology>()
                .ToTable("Technology")
                .HasKey(x => x.Id);

            modelBuilder.Entity<Technology>()
                .Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<Technology>()
                .Property(x => x.Description)
                .HasMaxLength(2000)
                .IsRequired();
        }
    }
}
