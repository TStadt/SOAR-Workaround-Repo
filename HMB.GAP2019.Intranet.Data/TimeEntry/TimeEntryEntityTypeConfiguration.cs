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
            builder.Property(te => te.Sunday);
            builder.Property(te => te.Monday);
            builder.Property(te => te.Tuesday);
            builder.Property(te => te.Wednesday);
            builder.Property(te => te.Thursday);
            builder.Property(te => te.Friday);
            builder.Property(te => te.Saturday);
            builder.Property(te => te.Task).IsRequired();
            builder.Property(te => te.Note).HasMaxLength(1000);
        }
    }
}