using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using JobSeeking.BE.API.Interfaces.Base;
using JobSeeking.BE.API.Middleware;
using JobSeeking.BE.API.Services.Base;
using JobSeeking.BE.ApplicationCore.Interfaces;
using JobSeeking.BE.ApplicationCore.Interfaces.Base;
using JobSeeking.BE.Infrashtructure.Data.Repositories;
using JobSeeking.BE.Infrashtructure.Data.Repositories.Base;
using JobSeeking.BE.Infrashtructure.DataContext;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using JobSeeking.BE.ApplicationCore.Entities.Mapping;
using JobSeeking.BE.ApplicationCore.Entities.Base;
using Microsoft.AspNetCore.Http;
using System.Text;
using JobSeeking.BE.API.Interfaces;
using JobSeeking.BE.API.Services;

namespace JobSeeking.BE.API
{
    public class Startup
    {
        /// <summary>
        /// Contructor
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// Configuration Interface
        /// </summary>
        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        /// <summary>
        /// ConfigureServices
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            DatabaseContext.ConnectionString = Configuration.GetConnectionString("connectionString");
            services.AddCors(options => options.AddPolicy("AllowAll", builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            })
            );

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                {
                    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;

                })
             .ConfigureApiBehaviorOptions(options =>
             {
                 options.SuppressModelStateInvalidFilter = true;
             });
            ;


            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Job Seeking Swagger", Version = "v1" });
                var xmlFile = Path.ChangeExtension(typeof(Startup).Assembly.Location, ".xml");
                //c.IncludeXmlComments(xmlFile);
            });

            // Config DI:
            services.AddScoped(typeof(IBaseEntityService<>), typeof(BaseService<>));
            services.AddScoped(typeof(IBaseRepository<>), typeof(BaseRepository<>));
            services.AddScoped(typeof(ICommonRepository<>), typeof(CommonRepository<>));

            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<IJobService, JobService>();

            services.AddScoped<ISpecialtyService, SpecialtyService>();
            services.AddScoped<ISpecialtyRepository, SpecialtyRepository>();



            var mappingConfig = new MapperConfiguration(mc =>
            {
                mc.AddProfile(new MappingProfile());
            });
            IMapper mapper = mappingConfig.CreateMapper();
            services.AddSingleton(mapper);




        }

        /// <summary>
        /// Configure
        /// </summary>
        /// <param name="app"></param>
        /// <param name="env"></param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Cấu hình CORS
            app.UseCors("AllowAll");

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            //Thực hiện validate header request
            //Tất cả service đều cần header có OrganizationID
            app.Use(async (context, next) =>
            {
                var actionResult = new ActionServiceResult();
                var path = context.Request.Path.ToString();
                //var organizationID = context.Request.Headers["OrganizationID"].ToString();
                if (path.Contains("api"))//&& string.IsNullOrEmpty(organizationID))
                {
                    context.Response.StatusCode = 401;
                    context.Response.ContentType = "application/json";
                    actionResult.Success = false;
                    actionResult.SystemCode = ApplicationCore.Enums.Enumeration.SystemCode.ValidateEntity;
                    actionResult.Message = JobSeeking.BE.ApplicationCore.Properties.Resources.ValidateEntity;
                    actionResult.Data = null;
                    var jsonString = JsonConvert.SerializeObject(actionResult);
                    await context.Response.WriteAsync(jsonString, Encoding.UTF8);
                    await context.Response.CompleteAsync();
                    return;
                }
                await next.Invoke();
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "MISA Mintasx Service version 1");
                c.RoutePrefix = "swagger";
            });
            app.UseHttpsRedirection();
            app.UseMiddleware(typeof(ErrorHandlingMiddleware));
            app.UseRouting();

            app.UseAuthorization();


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
