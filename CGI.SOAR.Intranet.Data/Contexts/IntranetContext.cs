using CGI.SOAR.Intranet.Core.Announcements;
using CGI.SOAR.Intranet.Core.Authentication;
using CGI.SOAR.Intranet.Core.TimesSheets;
using CGI.SOAR.Intranet.Data.Announcements;
using CGI.SOAR.Intranet.Data.Authentication;
using CGI.SOAR.Intranet.Data.TimeSheets;
using Microsoft.EntityFrameworkCore;

namespace CGI.SOAR.Intranet.Data.Contexts
{
    public class IntranetContext : DbContext
    {
        // ReSharper disable once SuggestBaseTypeForParameter
        public IntranetContext(DbContextOptions<IntranetContext> context) : base(context)
        { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<TimeEntryEntity> TimeEntries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AnnouncementEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TaskEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TimeEntryEntityTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
