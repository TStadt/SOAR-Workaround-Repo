using HMB.GAP2019.Intranet.Core.Announcements;
using HMB.GAP2019.Intranet.Core.Authentication;
using HMB.GAP2019.Intranet.Core.Task;
using HMB.GAP2019.Intranet.Core.Timesheet;
using HMB.GAP2019.Intranet.Data.Announcements;
using HMB.GAP2019.Intranet.Data.Authentication;
using HMB.GAP2019.Intranet.Data.Tasks;
using HMB.GAP2019.Intranet.Data.TimeSheets;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;


namespace HMB.GAP2019.Intranet.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.AddTransient<ITimeSheetService, TimeSheetService>();
            services.AddTransient<ITimeSheetRepository, TimeSheetRepository>();
            services.AddTransient<ITaskService, TaskService>();
            services.AddTransient<ITaskRepository, TaskRepository>();
            services.AddTransient<IAnnouncementService, AnnouncementService>();
            services.AddTransient<IAnnouncementRepository, AnnouncementRepository>();
            //services.AddTransient<IEmployeeAuthenticationService, EmployeeAuthenticationService>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();

            // Normal Web API adds

            services
                .AddCors()
                .AddApiVersioning(o => o.AssumeDefaultVersionWhenUnspecified = true);

            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
                });

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();

            }

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseAuthorization();



            app.UseCors(builder => builder.AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin());

            app.UseHttpsRedirection();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
