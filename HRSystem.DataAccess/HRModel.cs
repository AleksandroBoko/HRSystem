using HRSystem.DataAccess.Entity;
using HRSystem.DataAccess.ConfigurationModel;
using System.Data.Entity;

namespace HRSystem.DataAccess
{
    public class HRModel : DbContext
    {
        // Your context has been configured to use a 'HRModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'HRSystem.DataAccess.HRModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'HRModel' 
        // connection string in the application configuration file.
        public HRModel()
            : base("name=HRModel")
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        public virtual DbSet<Position> Positions { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            PositionConfig.Configure(modelBuilder);
            SpecializationConfig.Configure(modelBuilder);
            DepartmentConfig.Configure(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }
    }
}