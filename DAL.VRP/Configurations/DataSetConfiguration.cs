using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VRP.Entities;

namespace VRP.DAL.Configurations {
    public class DataSetConfiguration : ExpirableConfiguration<DataSet> {
        public override void Configure(EntityTypeBuilder<DataSet> builder) {
            base.Configure(builder);
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).HasMaxLength(100);
            builder.Property(x => x.Description).HasMaxLength(1000);
            builder.HasOne(x => x.User).WithMany().HasForeignKey(x => x.UserId);
        }
    }
}
