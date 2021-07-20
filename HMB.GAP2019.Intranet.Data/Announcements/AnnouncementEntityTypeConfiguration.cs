using System;
using HMB.GAP2019.Intranet.Core.Announcements;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HMB.GAP2019.Intranet.Data.Announcements
{
    internal class AnnouncementEntityTypeConfiguration : IEntityTypeConfiguration<Announcement>
    {
        public void Configure(EntityTypeBuilder<Announcement> builder)
        {
            builder.HasKey(a => a.Id);

            builder.Property(a => a.Id)
                .UseSqlServerIdentityColumn();
            builder.Property(a => a.Title)
                .HasMaxLength(500);

            builder.HasData(new[]
            {
            new Announcement
            {
               Id = 1,
               StartDate = new DateTime(2020, 6, 15, 0, 0, 0, DateTimeKind.Utc),
               EndDate = new DateTime(2020, 6, 23, 0, 0, 0, DateTimeKind.Utc),
               IsHighPriority = true,
               Title = "Welcome to the Angular portion of the Grad Academy Project",
               Body = @"##About
This is a markdown file. for more information about markdown please go to [this site](https://www.markdownguide.org/cheat-sheet)
",
            },
            new Announcement
            {
               Id = 2,
               StartDate = new DateTime(2020, 6, 17, 0, 0, 0, DateTimeKind.Utc),
               EndDate = new DateTime(2020, 6, 23, 0, 0, 0, DateTimeKind.Utc),
               IsHighPriority = false,
               Title = "Grad Academy Information",
               Body = @"##Members
* Adam Smith
* Alicia Jeffers
* Brandon Tietz
* Colin Evans
* Jacqueline Ortiz
* Ptoli Whittington
",
            },
            new Announcement
            {
               Id = 3,
               StartDate = new DateTime(2020, 6, 1, 0, 0, 0, DateTimeKind.Utc),
               EndDate = new DateTime(2020, 6, 23, 0, 0, 0, DateTimeKind.Utc),
               IsHighPriority = true,
               Title = "Welcome to the Grad Academy Presentation!",
               Body = @"##Project Breakdown
* Front end: [Angular](https://angular.io/)
* API: [ASP.NET Core 3.1 Web API](https://docs.microsoft.com/en-us/aspnet/core/?view=aspnetcore-3.1)
* Database: [LocalDB](https://docs.microsoft.com/en-us/sql/database-engine/configure-windows/sql-server-express-localdb?view=sqlallproducts-allversions)
",
            }
         });
        }
    }
}
