using iSele.Repository.Interfaces;
using iSele.Repository.Repositories;
using iSele.Services;
using iSele.Services.Tools;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using QOnTMSSql.Models;
using QOnTMSSql.Models.Interfaces;
using QOnTMSSql.Models.Repositories;

namespace QOnT2iSeleMigration.Web.FrontEnd
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddRazorPages();
            services.AddServerSideBlazor();
            //services.AddSingleton<WeatherForecastService>();
            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("iSeleConnection"));
                options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                options.EnableSensitiveDataLogging(true);
            });
            services.AddDbContext<QOnTDbContext>(qontoptions =>
            {
                qontoptions.UseSqlServer(Configuration.GetConnectionString("QOnTConnection"));
            });

            services.AddScoped(typeof(IQOnTFancyGenericRepository<>), typeof(QOnTFancyGenericRepository<>));

            services.AddScoped(typeof(IFancyGenericRepository<>), typeof(FancyGenericRepository<>));
            //            services.AddScoped(typeof(IFancyGenericRepository<ApplicationDbContext>), typeof(FancyGenericRepository<ApplicationDbContext>));

            services.AddScoped(typeof(IQOnTFancyGenericRepository<>), typeof(QOnTFancyGenericRepository<>));

            // logger
            services.AddSingleton<ILoggerManager, LoggerManager>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }


            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}
