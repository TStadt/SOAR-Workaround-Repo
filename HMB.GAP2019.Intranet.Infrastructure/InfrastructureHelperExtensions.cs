using HMB.GAP2019.Intranet.Core.Announcements;
using HMB.GAP2019.Intranet.Core.Authentication;
using HMB.GAP2019.Intranet.Infrastructure.Announcements;
using HMB.GAP2019.Intranet.Infrastructure.Authentication;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Internal;

namespace HMB.GAP2019.Intranet.Infrastructure
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
