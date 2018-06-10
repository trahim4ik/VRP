using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VRP.DAL.Configurations;
using VRP.Entities;

namespace VRP.DAL {
    public class ApplicationDbContext : IdentityDbContext<User, Role, long> {
        public DbSet<DataSet> DataSets { get; set; }
        public DbSet<DataSetItem> DataSetItems { get; set; }
        public DbSet<DataSetNetwork> DataSetNetworks { get; set; }
        public DbSet<DataSetPredict> DataSetPredicts { get; set; }
        public DbSet<FileEntry> FileEntries { get; set; }
        public DbSet<Realty> Realties { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            modelBuilder.ApplyConfiguration(new FileEntryConfiguration());
            modelBuilder.ApplyConfiguration(new DataSetConfiguration());
            modelBuilder.ApplyConfiguration(new DataSetFileEntryConfiguration());
            modelBuilder.ApplyConfiguration(new DataSetItemConfiguration());
            modelBuilder.ApplyConfiguration(new DataSetNetworkConfiguration());
            modelBuilder.ApplyConfiguration(new DataSetPredictConfiguration());

            modelBuilder.ApplyConfiguration(new RealtyConfiguration());
        }

    }
}
