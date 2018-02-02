using HRSystem.DataAccess.Entity;
using System.Data.Entity;

namespace HRSystem.DataAccess.ConfigurationModel
{
    public static class SpecializationConfig
    {
        public static void Configure(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Specialization>()
                .ToTable("Specialization")
                .HasKey(x => x.Id)
                .Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
