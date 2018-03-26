using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VRP.Entities;

namespace VRP.DAL.Configurations {
    public class DataSetItemConfiguration : ExpirableConfiguration<DataSetItem> {
        public override void Configure(EntityTypeBuilder<DataSetItem> builder) {
            base.Configure(builder);
            builder.HasKey(x => x.Id);
            builder.HasOne(x => x.DataSet).WithMany(x => x.DataSetItems).HasForeignKey(x => x.DataSetId);
        }
    }
}
