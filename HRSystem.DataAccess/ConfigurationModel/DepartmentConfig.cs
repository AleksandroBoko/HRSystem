using HRSystem.DataAccess.Entity;
using System.Data.Entity;

namespace HRSystem.DataAccess.ConfigurationModel
{
    public static class DepartmentConfig
    {
        public static void Configure(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Department>()
                .ToTable("Department")
                .HasKey(x => x.Id)
                .Property(x => x.Name)
                .HasMaxLength(200)
                .IsRequired();
        }
    }
}
