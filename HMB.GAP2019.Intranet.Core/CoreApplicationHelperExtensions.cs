using HMB.GAP2019.Intranet.Core.Announcements;
using HMB.GAP2019.Intranet.Core.ModelValidation;
using Microsoft.Extensions.DependencyInjection;

namespace HMB.GAP2019.Intranet.Core
{
    public static class CoreApplicationHelperExtensions
    {
        public static IServiceCollection AddCoreApplicationServices(this IServiceCollection services)
            => services
                .AddScoped<IModelValidationService, ModelValidationService>()
                .AddScoped<IAnnouncementService, AnnouncementService>();
    }
}
