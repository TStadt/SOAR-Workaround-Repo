using System;
using CGI.SOAR.Intranet.Core.Announcements;
using CGI.SOAR.Intranet.Core.Authentication;
using CGI.SOAR.Intranet.Core.TimesSheets;
using CGI.SOAR.Intranet.Data.Announcements;
using CGI.SOAR.Intranet.Data.Authentication;
using CGI.SOAR.Intranet.Data.Contexts;
using CGI.SOAR.Intranet.Data.TimeSheets;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;


namespace CGI.SOAR.Intranet.Data
{
    public static class DatabaseHelperExtensions
    {
        public static IServiceCollection AddEntityFrameworkRepositories(this IServiceCollection services,
            Action<DbContextOptionsBuilder> setup) =>
            services.AddDbContext<IntranetContext>(setup)
                .AddScoped<IEmployeeRepository, EmployeeRepository>()
                .AddScoped<IAnnouncementRepository, AnnouncementRepository>()
                .AddScoped<ITaskRepository, TaskRepository>()
                .AddScoped<ITimeSheetRepository, TimeSheetRepository>();

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
