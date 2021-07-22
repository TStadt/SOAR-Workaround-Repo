using HMB.GAP2019.Intranet.Core.Timesheet;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HMB.GAP2019.Intranet.Data.TimeSheets
{
    public class TimeEntryEntityTypeConfiguration : IEntityTypeConfiguration<TimeEntry>
    {

        public void Configure(EntityTypeBuilder<TimeEntry> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .UseSqlServerIdentityColumn();

            builder.Property(e => e.Monday);
            builder.Property(e => e.Tuesday);
            builder.Property(e => e.Wednesday);
            builder.Property(e => e.Thursday);
            builder.Property(e => e.Friday);
            builder.Property(e => e.Saturday);
            builder.Property(e => e.Sunday);

            builder.Property(e => e.Note);
        }
    }
}