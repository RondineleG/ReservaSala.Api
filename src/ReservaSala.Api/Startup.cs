using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Refit;
using ReservaSala.Api.Data;
using ReservaSala.Api.Domain.Repositories;
using ReservaSala.Api.Domain.Services;
using ReservaSala.Api.Extensions;
using ReservaSala.Api.Models;
using ReservaSala.Api.Persistence.Repositories;
using ReservaSala.Api.Repositories;
using ReservaSala.Api.Services;
using Swashbuckle.AspNetCore.SwaggerUI;
using System;

namespace ReservaSala.Api
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
            services.ConfigureCors();
            services.ConfigureIISIntegration();

            services.AddControllersWithViews();
            services.AddDbContext<AppDbContext>(options =>
                    options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();

            services.AddRefitClient<ICategoryRest>()
                    .ConfigureHttpClient(c => c.BaseAddress = new Uri(Configuration.GetSection("Apis:CountryApi:Url").Value));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = " Web API",
                    Description = "A simple example ASP.NET Core Web API",
                    TermsOfService = new Uri("https://github.com/RondineleG/ReservaSala.Api/blob/master/README.md"),
                    Contact = new OpenApiContact
                    {
                        Name = "Rondinele Guimarães",
                        Email = "rondineleg@gmai.com",
                        Url = new Uri("https://github.com/rondineleg"),
                    },
                    License = new OpenApiLicense
                    {
                        Name = "MIT",
                        Url = new Uri("https://github.com/RondineleG/ReservaSala.Api/blob/master/LICENSE"),
                    }
                });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
                c.DocumentTitle = "Todo APIs";
                c.DocExpansion(DocExpansion.None);
                c.RoutePrefix = string.Empty;
            });

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseCors("CorsPolicy");

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All
            });


            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=home}/{action=Index}/{id?}");
            });
        }
    }
}
