using CGI.SOAR.Intranet.Core.TimesSheets;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CGI.SOAR.Intranet.Data.TimeSheets
{
    internal class TaskEntityTypeConfiguration : IEntityTypeConfiguration<Task>
    {
        public void Configure(EntityTypeBuilder<Task> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).UseIdentityColumn();
            builder.Property(e => e.Name).HasMaxLength(300);

            builder.HasData(new[]
            {
            new Task { Id = 1, Name = "Deployment" },
            new Task { Id = 2, Name = "Design" },
            new Task { Id = 3, Name = "Develop" },
            new Task { Id = 4, Name = "Marketing" },
            new Task { Id = 5, Name = "Meeting" },
            new Task { Id = 6, Name = "Other", IsNoteRequired= true },
            new Task { Id = 7, Name = "Out of Office" },
            new Task { Id = 8, Name = "Project Management" },
            new Task { Id = 9, Name = "Release Management" },
            new Task { Id = 10, Name = "Requirements" },
            new Task { Id = 11, Name = "Testing" }
         });
        }
    }
}