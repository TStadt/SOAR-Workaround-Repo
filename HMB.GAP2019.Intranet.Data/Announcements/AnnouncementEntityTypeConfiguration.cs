using HMB.GAP2019.Intranet.Core.Announcements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HMB.GAP2019.Intranet.Data.Contexts
{
    public class AnnouncementEntityTypeConfiguration : IEntityTypeConfiguration<Announcement>
    {
        public void Configure(EntityTypeBuilder<Announcement> builder)
        {
            builder.HasKey(a => a.Id);
            builder.Property(a => a.Id).UseIdentityColumn();
            builder.Property(a => a.StartDate);
            builder.Property(a => a.EndDate);
            builder.Property(a => a.IsHighPriority);
            builder.Property(a => a.Title).IsRequired().HasMaxLength(500);
            builder.Property(a => a.Body).IsRequired();
        }
    }
}