using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Toy.Entities.Interfaces;
using Toy.Persistance.Database;
using Toy.Persistance.Repository;
using Toy.Services.Services;

namespace ToyProject.API
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
            //repositories
            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IContactServices, ContactServices>();
            services.AddScoped<IProductServices, ProductServices>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddDbContext<AppDbContext>
               (o => o.UseSqlServer(Configuration.GetConnectionString("ToyDb")));

            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}