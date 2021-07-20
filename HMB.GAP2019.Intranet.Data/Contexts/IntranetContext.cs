using HMB.GAP2019.Intranet.Core.Authentication;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new EmployeeEntityTypeConfiguration());

            base.OnModelCreating(modelBuilder);
        }
    }
}
