using HMB.GAP2019.Intranet.Core.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HMB.GAP2019.Intranet.Data.Contexts
{
    public class TasksEntityTypeConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Id).UseSqlServerIdentityColumn();
            builder.Property(t => t.Name).IsRequired().HasMaxLength(300);
            builder.Property(t => t.timeEntries);
            builder.Property(t => t.RequiresNote);
        }
    }
}