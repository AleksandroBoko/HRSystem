using HRSystem.DataAccess.Entity;
using System.Data.Entity;

namespace HRSystem.DataAccess.ConfigurationModel
{
    public static class PositionConfig
    {
        public static void Configure(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>()
                .ToTable("Position")
                .HasKey(x => x.Id)
                .Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
