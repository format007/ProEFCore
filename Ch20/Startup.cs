using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Ch20.Models.Entities;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Ch20.Tools;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.AspNet.OData.Extensions;
using Microsoft.AspNet.OData.Builder;
using Microsoft.OData.Edm;

namespace Ch20
{
    public class Startup
    {

        public IConfiguration Configuration;

        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            string conStr = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ProductDbContext>(opt =>
                opt.UseSqlServer(conStr));
            services.AddControllers(cfg=>cfg.EnableEndpointRouting = false)
                 .AddNewtonsoftJson(); 
            services.AddSwaggerDefault();
            services.AddOData();
            services.AddDirectoryBrowser();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerDefault();
            }

            app.UseDirectoryBrowser();
            app.UseStatusCodePages();
            app.UseMvc(routeBuilder =>
            {
                routeBuilder.EnableDependencyInjection();
                routeBuilder.Select().Filter().OrderBy().Expand().Count() ;
                //routeBuilder.MapODataServiceRoute("odata", "odata", GetEdmModel());
            });
            //app.UseRouting();
            //app.UseEndpoints(cfg =>
            //{
            //    cfg.MapControllers();
            //});

            IEdmModel GetEdmModel()
            {
                var odataBuilder = new ODataConventionModelBuilder();
                odataBuilder.EntitySet<Product>("Product");

                return odataBuilder.GetEdmModel();
            }
        }
    }
}
