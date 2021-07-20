using HMB.GAP2019.Intranet.Core.Announcements;
using HMB.GAP2019.Intranet.Core.Authentication;
using HMB.GAP2019.Intranet.Core.Tasks;
using HMB.GAP2019.Intranet.Core.TimeSheets;
using HMB.GAP2019.Intranet.Data.Authentication;
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
        public DbSet<Task> Tasks{ get; set; }
        public DbSet<TimeSheet> Timesheet { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TasksEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new AnnouncementEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TimeSheetsEntityTypeConfiguration());
            modelBuilder.ApplyConfiguration(new TimeEntryEntityTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
