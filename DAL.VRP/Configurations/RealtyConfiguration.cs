using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VRP.Entities;

namespace VRP.DAL.Configurations {
    public class RealtyConfiguration : ExpirableConfiguration<Realty> {
        public override void Configure(EntityTypeBuilder<Realty> builder) {
            base.Configure(builder);
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
            builder.Property(x => x.ZipCode).HasMaxLength(20);
        }
    }
}
