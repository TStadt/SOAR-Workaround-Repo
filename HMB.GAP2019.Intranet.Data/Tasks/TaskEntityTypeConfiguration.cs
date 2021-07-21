using HMB.GAP2019.Intranet.Core.Tasks;
using HMB.GAP2019.Intranet.Core.Timesheet;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace HMB.GAP2019.Intranet.Data.Tasks
{
    public class TaskEntityTypeConfiguration : IEntityTypeConfiguration<Core.Tasks.Task>
    {
        public void Configure(EntityTypeBuilder<Core.Tasks.Task> builder)
        {
            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                .UseSqlServerIdentityColumn();

            builder.Property(t => t.Name)
                .IsRequired()
                .HasMaxLength(300);
            builder.Property(t => t.IsNoteRequired);


        }
    }
}
