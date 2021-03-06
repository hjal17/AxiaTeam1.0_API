using AxiaTeam1._0.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AxiaTeam1._0.Helpers;
using AxiaTeam1._0.Data.Tache;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using AxiaTeam1._0.Data.Middlware;
using AxiaTeam1._0.Models;
using AxiaTeam1._0.Data.BackLogRepository;
using AxiaTeam1._0.Data.UserStoryRepository;
using AxiaTeam1._0.Data.ClientRepository;
using AxiaTeam1._0.Data.EquipeRepository;
using AxiaTeam1._0.Data.EmployeeEquipeRepository;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace AxiaTeam1._0
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
         
           services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddSession();
            services.AddMvc();
          
            services.AddCors();
            services.AddDbContext<DataContext>(opt =>opt.UseSqlServer(Configuration.GetConnectionString("Default")));
            services.AddSignalRCore();
            services.AddControllers();
            services.AddSignalR();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IProjectRepository, ProjectRepository>();
            services.AddScoped<ITacheRepository, TacheRepository>();
            services.AddScoped<IBackLogRepository, BackLogRepository>();
            services.AddScoped<IUserStoryRepository, UserStoryRepository>();
            services.AddScoped<IEquipeRepository, EquipeRepository>();
            services.AddScoped<IEmployeeEquipeRepository, EmployeeEquipeRepository>();
            services.AddScoped<JwtService>();
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
                options.DefaultSignOutScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            });



        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseSession();
            app.UseRouting();
            
            app.UseCors(options => options         
                                    .WithOrigins("http://localhost:3000", "http://localhost:8080", "http://localhost:4200")
                                    .AllowAnyHeader()
                                    .AllowAnyMethod()
                                    .AllowCredentials()
                                    );

            app.UseAuthorization();
            app.UseAuthentication();
            
            app.UseEndpoints(endpoints =>
            {
               
                endpoints.MapControllers();
                endpoints.MapHub<ChatHub>("/pushNotification");
            });
           
          
            // Add framework services.
            app.UseMiddleware<AuthenticationMiddleware>();
        }
    }
}
