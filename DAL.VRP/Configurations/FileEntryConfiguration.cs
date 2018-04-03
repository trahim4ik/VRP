using Microsoft.EntityFrameworkCore.Metadata.Builders;
using VRP.Entities;

namespace VRP.DAL.Configurations {
    public class FileEntryConfiguration : ExpirableConfiguration<FileEntry> {
        public override void Configure(EntityTypeBuilder<FileEntry> builder) {
            base.Configure(builder);
            builder.HasKey(x => x.Id);
        }
    }
}
