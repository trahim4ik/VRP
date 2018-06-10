using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VRP.Entities;

namespace VRP.DAL.Configurations {
    public class DataSetPredictConfiguration : IEntityTypeConfiguration<DataSetPredict> {
        public void Configure(EntityTypeBuilder<DataSetPredict> builder) {
            builder.HasKey(x => x.Id);

            builder
                .HasOne(x => x.DataSet)
                .WithMany(x => x.DataSetPredicts)
                .HasForeignKey(x => x.DataSetId);
        }
    }
}
