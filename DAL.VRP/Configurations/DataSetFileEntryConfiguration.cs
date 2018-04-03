using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VRP.Entities;

namespace VRP.DAL.Configurations {
    public class DataSetFileEntryConfiguration : IEntityTypeConfiguration<DataSetFileEntry> {
        public void Configure(EntityTypeBuilder<DataSetFileEntry> builder) {
            builder.HasKey(t => new { t.FileEntryId, t.DataSetId });

            builder
                .HasOne(pt => pt.DataSet)
                .WithMany(p => p.DataSetFileEntries)
                .HasForeignKey(pt => pt.DataSetId);

            builder
                .HasOne(pt => pt.FileEntry)
                .WithMany(p => p.DataSetFileEntries)
                .HasForeignKey(pt => pt.FileEntryId);
        }
    }
}
