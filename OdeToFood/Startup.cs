using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OdeToFood.Models;
using OdeToFood.Services;

namespace OdeToFood
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
            services.AddDbContext<OdeToFoodDBContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddMvc();

            services.AddDbContext<OdeToFoodDBContext>(options => options.UseSqlServer(Configuration["database:connection"]));

            services.AddSingleton(provider => Configuration);
            services.AddSingleton<IGreeter, Greeter>();
            services.AddScoped<IRestaurantData, SQLRestaurantData>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env,
            IConfiguration configuration,
            IGreeter greeter,
            ILogger<Startup> logger)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseMvc(ConfigureRoutes);

            app.Run(async (context) =>
            {
                //var greeting = greeter.GetMessageOfTheDay();
                context.Response.ContentType = "text/plain";
                await context.Response.WriteAsync($"Not found");

            });

        }

        private void ConfigureRoutes(IRouteBuilder routeBuilder)
        {
            // /Home/Index/4

            routeBuilder.MapRoute("Default", "{controller=Home}/{action=Index}/{id?}");
        }

    }

}




//app.Use(next =>
//{
//return async context =>
//await next(context);


//{
//    logger.LogInformation("Request Incoming");
//    if (context.Request.Path.StartsWithSegments("/mym"))
//    {
//        await context.Response.WriteAsync("Hit!!");
//        logger.LogInformation("Request handled");
//    }
//    else
//    {
//        await next(context);
//        logger.LogInformation("Request OUTcoming");
//    }
//};
//});

//app.UseWelcomePage(new WelcomePageOptions
//{
//    Path="/wp"
//});

//if (env.IsDevelopment())
//{
//    app.UseDeveloperExceptionPage();
//}
//else
//{

//}