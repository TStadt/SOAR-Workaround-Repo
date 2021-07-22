using HMB.GAP2019.Intranet.Core.Announcements;
using HMB.GAP2019.Intranet.Core.Authentication;
using HMB.GAP2019.Intranet.Core.Tasks;
using HMB.GAP2019.Intranet.Core.Timesheet;
using HMB.GAP2019.Intranet.Data.Announcements;
using HMB.GAP2019.Intranet.Data.Authentication;
using HMB.GAP2019.Intranet.Data.Tasks;
using HMB.GAP2019.Intranet.Data.TimeSheets;
using Microsoft.EntityFrameworkCore;

namespace HMB.GAP2019.Intranet.Data.Contexts
{
    public class IntranetContext : DbContext
    {
        // ReSharper disable once SuggestBaseTypeForParameter
        public IntranetContext(DbContextOptions<IntranetContext> context) : base(context)
        { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Task> Task { get; set; }
        public DbSet<TimeEntry> TimeEntry { get; set; }
        public DbSet<TimeSheet> TimeSheet { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AnnouncementEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TimeSheetEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TimeSheetEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TaskEntityTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}