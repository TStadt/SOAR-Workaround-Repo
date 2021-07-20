using HMB.GAP2019.Intranet.Core.TimeEntry;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HMB.GAP2019.Intranet.Data.Contexts
{
    public class TimeEntryEntityTypeConfiguration : IEntityTypeConfiguration<Core.TimeEntry.TimeEntry>
    {
        public void Configure(EntityTypeBuilder<Core.TimeEntry.TimeEntry> builder)
        {
            builder.HasKey(te => te.Id);
            builder.Property(te => te.Id).UseSqlServerIdentityColumn();
            builder.Property(te => te.Day);
            builder.Property(te => te.task).IsRequired();
            builder.Property(te => te.Note).HasMaxLength(1000);
        }
    }
}