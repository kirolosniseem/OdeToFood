using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OdeToFood.Services;
using OdeToFoodData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UsersIdentity;

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
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages()
                .AddMvcOptions(options => options.Filters.Add(new AuthorizeFilter()));

            services.AddControllers();

            services.AddIdentity<OdeToFoodUser, IdentityRole>()
                .AddEntityFrameworkStores<UserIdentityDBContext>()
                .AddDefaultUI()
                .AddDefaultTokenProviders();

            services.AddDbContextPool<OdeToFoodDBContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("OdeToFoodDB"));
                });

            services.AddDbContextPool<UserIdentityDBContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("UserIdentity"));
            });

            //services.AddSingleton<IRestaurantRepository, RestaurantInMemoryRepo>();
            services.AddScoped<IRestaurantRepository, RestaurantSQLDatabaseRepo>();

            services.AddScoped<IEmailSender, EmailSender>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.Use(CustomMiddlewareWho);

            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
        }

        private RequestDelegate CustomMiddlewareWho(RequestDelegate arg)
        {
            return async ctx =>
            {
                if (ctx.Request.Path.StartsWithSegments("/who"))
                {
                    //execute this middle ware and stop
                    await ctx.Response.WriteAsync("Kirolos Niseem");
                }
                else
                {
                    //pass to next middleware
                    await arg(ctx);
                }
            };
        }

    }
}
