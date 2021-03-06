using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using WebJob.Models;
using Microsoft.EntityFrameworkCore;
using WebJob.Interfaces;

using WebJob.Data;
using Microsoft.AspNetCore.Connections;
using WebJob.Data.Repository;
using Microsoft.AspNetCore.Identity;
using WebJob.Data.Models;

namespace WebJob
{
    public class Startup

    {
        private IConfigurationRoot _conStr;
        public Startup(IHostEnvironment host) 
        {
            _conStr = new ConfigurationBuilder().SetBasePath(host.ContentRootPath).AddJsonFile("dbset.json").Build();
        }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddDbContext<AppDBContent>(options => options.UseSqlServer(_conStr.GetConnectionString("DefaultConnection")));
            services.AddControllersWithViews();
            services.AddMvcCore();
            //Identity 
            services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<AppDBContent>();
            services.AddAuthentication();
            services.AddAuthorization();
               
            //���������� ����������� 
            services.AddTransient<ICategory, CategoryRepository>();
            services.AddTransient<ITovar, TovarRepository>();
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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
            app.UseStatusCodePages();
            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=List}/{id?}");
              
            });

            
            using (var scope = app.ApplicationServices.CreateScope())
            {
                AppDBContent content = scope.ServiceProvider.GetRequiredService<AppDBContent>();
                var userManger = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
                var rolesManger = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

                await DBObjects.Initial(content,userManger,rolesManger);
            }
        }
    }
}
