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
            services.AddControllers();
            services.AddSwaggerDefault();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwaggerDefault();
            }

            app.UseStaticFiles();
            app.UseStatusCodePages();
            app.UseRouting();
            app.UseEndpoints(cfg => cfg.MapControllers());
        }
    }
}
