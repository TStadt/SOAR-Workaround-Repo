using CGI.SOAR.Intranet.Core.Announcements;
using CGI.SOAR.Intranet.Core.ModelValidation;
using CGI.SOAR.Intranet.Core.TimesSheets;
using Microsoft.Extensions.DependencyInjection;

namespace CGI.SOAR.Intranet.Core
{
    public static class CoreApplicationHelperExtensions
    {
        public static IServiceCollection AddCoreApplicationServices(this IServiceCollection services)
            => services
                .AddScoped<IModelValidationService, ModelValidationService>()
                .AddScoped<IAnnouncementService, AnnouncementService>()
                .AddScoped<ITimeSheetService, TimeSheetService>();
    }
}
