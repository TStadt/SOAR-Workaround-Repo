using CGI.SOAR.Intranet.Core.Announcements;
using CGI.SOAR.Intranet.Core.Authentication;
using CGI.SOAR.Intranet.Infrastructure.Announcements;
using CGI.SOAR.Intranet.Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Internal;

namespace CGI.SOAR.Intranet.Infrastructure
{
    public static class InfrastructureHelperExtensions
    {
        public static IServiceCollection AddInMemoryRepositories(this IServiceCollection services)
            => services
                .AddScoped<IAnnouncementRepository, InMemoryAnnouncementRepository>()
                .AddScoped<IEmployeeRepository, InMemoryEmployeeRepository>();

        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
            => services
                .AddTransient<ISystemClock, SystemClock>()
                .AddScoped<IEmployeeAuthenticationService, HttpContextEmployeeAuthenticationService>();
    }
}
