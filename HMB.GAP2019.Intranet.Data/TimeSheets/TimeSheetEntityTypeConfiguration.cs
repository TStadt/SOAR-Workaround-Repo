using HMB.GAP2019.Intranet.Core.Authentication;
using HMB.GAP2019.Intranet.Core.Timesheet;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMB.GAP2019.Intranet.Data.TimeSheets
{
    public class TimeSheetEntityTypeConfiguration : IEntityTypeConfiguration<TimeSheet>
    {

        public void Configure(EntityTypeBuilder<TimeSheet> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .UseSqlServerIdentityColumn();

            builder.Property(e => e.Entries);
            builder.Property(e => e.Employee);
            builder.Property(e => e.MondayOfWeek);

            builder.HasMany(t => t.Entries)
                .WithOne(t => t.TimeSheet);

            builder.HasOne(e => e.Employee);
            
        }
    }
}
