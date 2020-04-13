using Agatha.Application.Infrastructure;
using Agatha.Application.Infrastructure.AutoMapper;
using Agatha.Persistence;
using AutoMapper;
using MediatR;
using MediatR.Pipeline;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using Agatha.WebUI.Filters;
using Agatha.Application.Products.Queries.GetProduct;
using Agatha.Application.Customers.Queries.GetAllCustomers;
using Agatha.Application.Interfaces;
using Agatha.Infrasctructure;
using Newtonsoft.Json;
using Microsoft.OpenApi.Models;
namespace API
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
            services.AddCors();

            // Add AutoMapper
            services.AddAutoMapper(new Assembly[] { typeof(AutoMapperProfile).GetTypeInfo().Assembly });

            // Add framework services.
            services.AddTransient<IAzureService, AzureService>();
            services.AddTransient<ILocalPhotoFileService, LocalPhotoFileService>();

            services.AddTransient<IDischargeService, MundiPaggService>();

            // Add MediatR
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPreProcessorBehavior<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceBehaviour<,>));
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
            services.AddMediatR(typeof(GetProductQueryHandler).GetTypeInfo().Assembly);

            services.AddMediatR(typeof(GetCustomerListQuery).GetTypeInfo().Assembly);

            // Add DbContext using SQL Server Provider
            services.AddDbContext<AgathaDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("AgathaDatabase")));

            services
                           .AddMvc(options => options.Filters.Add(typeof(CustomExceptionFilterAttribute)))
                           .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            // Customise default API behavour
            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            // In production, the Angular files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddMvc().AddJsonOptions(options => options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(c => {

                c.SwaggerDoc("v1",
                    new OpenApiInfo
                    {
                        Title = "Agatha API",
                        Version = "v1",
                        Description = "s",
                        Contact = new OpenApiContact
                        {
                            Name = "Daniel Arruda"
                          
                        }
                    });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseCors(
        options => options.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader()
    );
            // Ativando middlewares para uso do Swagger
            app.UseSwagger();
            app.UseSwaggerUI(c => {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Indicadores Econômicos V1");
            });

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

        }
    }
}
