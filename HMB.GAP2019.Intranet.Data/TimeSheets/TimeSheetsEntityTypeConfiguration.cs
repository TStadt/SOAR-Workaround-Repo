using HMB.GAP2019.Intranet.Core.TimeSheets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HMB.GAP2019.Intranet.Data.Contexts
{
    public class TimeSheetsEntityTypeConfiguration : IEntityTypeConfiguration<TimeSheet>
    {
        public void Configure(EntityTypeBuilder<TimeSheet> builder)
        {
            builder.HasKey(ts => ts.Id);
            builder.Property(ts => ts.Id).UseIdentityColumn();
            builder.Property(ts => ts.Week).IsRequired();
            builder.Property(ts => ts.Employee).IsRequired();
            builder.Property(ts => ts.TimeEntries);
        }
    }
}