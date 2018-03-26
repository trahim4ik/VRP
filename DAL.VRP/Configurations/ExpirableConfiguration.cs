using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VRP.Core.Interfaces;

namespace VRP.DAL.Configurations {
    public abstract class ExpirableConfiguration<T> : IEntityTypeConfiguration<T> where T : class, IExpirable {
        public virtual void Configure(EntityTypeBuilder<T> builder) {
            builder.Property(x => x.InsertDate).HasDefaultValueSql("GETDATE()");
        }
    }
}
