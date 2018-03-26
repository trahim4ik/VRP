﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VRP.DAL.Configurations;
using VRP.Entities;

namespace VRP.DAL {
    public class ApplicationDbContext : IdentityDbContext<User, Role, long> {

        public DbSet<DataSet> DataSets { get; set; }
        public DbSet<DataSetItem> DataSetItems { get; set; }
        public DbSet<Realty> Realties { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new RoleConfiguration());

            modelBuilder.ApplyConfiguration(new DataSetConfiguration());
            modelBuilder.ApplyConfiguration(new DataSetItemConfiguration());

            modelBuilder.ApplyConfiguration(new RealtyConfiguration());
        }

    }
}
