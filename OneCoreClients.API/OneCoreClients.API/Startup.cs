using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OneCoreClients.API.Middleware;
using OneCoreClients.DataAccess;
using OneCoreClients.DataAccess.Repository;
using OneCoreClients.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace OneCoreClients.API
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

            services.AddDbContextPool<AppDbContext>(o =>
            {
                o.UseSqlite(Configuration.GetConnectionString("Sqlite"));
            });

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IClientServices, ClientServices>();
            

            services.AddSwaggerGen(swagger=> {

                swagger.SwaggerDoc("v1", new Swashbuckle.AspNetCore.Swagger.Info
                {
                    Version = "v1",
                    Title = "ToDo API",
                    Description = "An ASP.NET Core Web API for managing ToDo items",
                    TermsOfService = "https://example.com/terms",
                    Contact = new Swashbuckle.AspNetCore.Swagger.Contact
                    {
                        Name = "Example Contact",
                        Url = "https://example.com/contact"
                    },
                    License = new Swashbuckle.AspNetCore.Swagger.License
                    {
                        Name = "Example License",
                        Url = "https://example.com/license"
                    }
                });
            });

            services.AddMvc();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, AppDbContext ctx)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://
                // aka.ms/aspnetcore-hsts.
                app.UseDeveloperExceptionPage();
                app.UseHsts();
            }

            
            ctx.Database.EnsureCreated();
            ctx.Database.Migrate();
            

            
            app.UseHttpsRedirection();
            app.UseMiddleware<GlobalResquestHandlerMiddleware>();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c => 
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Api1");
                c.RoutePrefix = string.Empty;
            });
        }
    }
}
