using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Movie_Repo.Repositories;
using Movie_Repo.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Movie_Repo
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            services.AddCors(option =>
            {
                option.AddPolicy("AllowSpecificOrigins", builder =>
                {
                    builder.WithOrigins("http://localhost:3000")
                    .AllowAnyHeader()   
                    .AllowAnyMethod();
                });
            });

            services.AddControllersWithViews();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });

            //Now register our services with Autofac container
            var builder = new ContainerBuilder();
            var dataAccess = Assembly.GetExecutingAssembly();
            builder.RegisterAssemblyTypes(dataAccess);

            // Register your Services.
            builder.RegisterAssemblyTypes(typeof(MasterMovieService).Assembly)
                .Where(t => t.Name.EndsWith("Service"))
                .AsImplementedInterfaces()
                .SingleInstance();

            //Register your Repository.
            builder.RegisterAssemblyTypes(typeof(MasterMovieRepository).Assembly)
                .Where(t => t.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .SingleInstance();

            builder.Populate(services);
            var container = builder.Build();
            return new AutofacServiceProvider(container);

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

            app.UseCors("AllowSpecificOrigins");

            // Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });



            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
