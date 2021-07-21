using HMB.GAP2019.Intranet.Core.Authentication;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HMB.GAP2019.Intranet.Data.Authentication
{
    internal class EmployeeEntityTypeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id)
                .UseSqlServerIdentityColumn();
            builder.Property(e => e.Email)
                .HasMaxLength(300);
            builder.Property(e => e.FirstName)
                .HasMaxLength(100);
            builder.Property(e => e.LastName)
                .HasMaxLength(100);


            builder.HasData(new[]
            {
                new Employee { Id = 1, Email = "alice.jones.admin@hmbnet.com", FirstName = "Alice", LastName = "Jones" },
                new Employee { Id = 2, Email = "john.smith.employee@hmbnet.com", FirstName = "John", LastName = "Smith" },
                new Employee { Id = 3, Email = "pamela.rogers.pm@hmbnet.com", FirstName = "Pamela", LastName = "Rogers" },
                new Employee { Id = 4, Email = "carter.cruz.hr@hmbnet.com", FirstName = "Carter", LastName = "Cruz" }
            });
        }
    }
}
