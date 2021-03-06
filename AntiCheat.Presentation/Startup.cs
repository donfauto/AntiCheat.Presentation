using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using AntiCheat.DataAccess.DbContexts;
using AntiCheat.DataAccess.Repositories.Contracts;
using AntiCheat.DataAccess.Repositories;
using AntiCheat.BusinessLogic.Services.Contracts;
using AntiCheat.BusinessLogic.Services;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace AntiCheat.Presentation
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
            services.AddControllersWithViews();
            services.AddDbContext<AntiCheatDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("Connection")));
            services.AddTransient<ITicketRepository, TicketRepository>();
            services.AddTransient<IBuyerRepository, BuyerRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ITicketSaleRepository, TicketSaleRepository>();
            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<ITicketService, TicketService>();
<<<<<<< HEAD
=======
            services.AddTransient<IUserService, UserService>();


>>>>>>> 4b5e1739a7dd3ca991b39b3d449dad7240699266
            services.AddTransient<ITicketSaleService, TicketSaleService>();
            services.AddTransient<IBuyerService, BuyerService>();
            services.AddTransient<IUserService, UserService>();

            services.AddAuthentication(options =>
            {
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            }).AddCookie(options => { options.LoginPath = "/User/Login"; });
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
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=User}/{action=Login" +
                    "}/{id?}");
            });
        }
    }
}
