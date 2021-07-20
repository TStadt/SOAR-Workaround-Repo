using System;
using HMB.GAP2019.Intranet.Core.Announcements;
using HMB.GAP2019.Intranet.Core.Authentication;
using HMB.GAP2019.Intranet.Data.Authentication;
using HMB.GAP2019.Intranet.Data.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;


namespace HMB.GAP2019.Intranet.Data
{
    public static class DatabaseHelperExtensions
    {
        public static IServiceCollection AddEntityFrameworkRepositories(this IServiceCollection services,
            Action<DbContextOptionsBuilder> setup) =>
            services.AddDbContext<IntranetContext>(setup)
                .AddScoped<IEmployeeRepository, EmployeeRepository>();

        public static IServiceCollection AddEntityFrameworkRepositories(this IServiceCollection services,
            string connection) =>
            services.AddEntityFrameworkRepositories(options => options.UseServer(connection));

        public static void UseAutomaticIntranetDatabaseMigrations(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope();
            scope.ServiceProvider.GetRequiredService<IntranetContext>().Database.Migrate();
        }

        internal static DbContextOptionsBuilder UseServer(this DbContextOptionsBuilder options, string connection)
            => options.UseSqlServer(connection);
    }
}
