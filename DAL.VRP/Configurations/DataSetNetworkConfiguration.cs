using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VRP.Entities;

namespace VRP.DAL.Configurations {
    public class DataSetNetworkConfiguration : ExpirableConfiguration<DataSetNetwork> {
        public override void Configure(EntityTypeBuilder<DataSetNetwork> builder) {
            base.Configure(builder);
            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.DataSet)
                .WithMany(x => x.DataSetNetworks)
                .HasForeignKey(x => x.DataSetId);

            builder
                .HasOne(pt => pt.FileEntry)
                .WithMany()
                .HasForeignKey(pt => pt.FileEntryId);
        }
    }
}
