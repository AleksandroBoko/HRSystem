using HRSystem.DataAccess.Entity;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;

namespace HRSystem.DataAccess.ConfigurationModel
{
    public static class EmployeeConfig
    {
        public static void Configure(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .ToTable("Employee")
                .HasKey(x => x.Id)
                .Property(x => x.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            modelBuilder.Entity<Employee>()
                .Property(x => x.Code)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(x => x.DateBorn)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(x => x.FirstName)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(x => x.SecondName)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(x => x.LastName)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .Property(x => x.Image)
                .HasMaxLength(200)
                .IsRequired();

            modelBuilder.Entity<Employee>()
                .HasRequired(x => x.EmpDepartment)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.DepartmentId);

            modelBuilder.Entity<Employee>()
                .HasRequired(x => x.EmpPosition)
                .WithMany(x => x.Employees)
                .HasForeignKey(x => x.PositionId);

            modelBuilder.Entity<Employee>()
                .HasRequired(x => x.EmpSpecialization)
                .WithMany(x => x.Employess)
                .HasForeignKey(x => x.SpecializationId);

            modelBuilder.Entity<Employee>()
                .HasMany(x => x.Technologies)
                .WithMany(x => x.Employess);

        }
    }
}
