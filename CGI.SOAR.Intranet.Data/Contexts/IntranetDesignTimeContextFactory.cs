using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace CGI.SOAR.Intranet.Data.Contexts
{
    public class IntranetDesignTimeDbContextFactory : IDesignTimeDbContextFactory<IntranetContext>
    {
        public IntranetContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<IntranetContext>();
            optionsBuilder.UseServer(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=GAP2019;Integrated Security=true");

            return new IntranetContext(optionsBuilder.Options);
        }
    }
}
