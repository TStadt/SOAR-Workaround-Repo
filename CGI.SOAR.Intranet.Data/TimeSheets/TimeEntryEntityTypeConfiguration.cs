using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CGI.SOAR.Intranet.Data.TimeSheets
{
    internal class TimeEntryEntityTypeConfiguration : IEntityTypeConfiguration<TimeEntryEntity>
    {
        public void Configure(EntityTypeBuilder<TimeEntryEntity> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.Note).HasMaxLength(1000);
        }
    }
}
