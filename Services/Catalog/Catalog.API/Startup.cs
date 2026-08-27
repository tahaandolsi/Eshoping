using Catalog.Application.Handlers;
using Catalog.Core.Repositories;
using Catalog.Infrastructure.Data;
using Catalog.Infrastructure.Repositories;
using HealthChecks.UI.Client;
using MediatR;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

using Microsoft.Extensions.Diagnostics.HealthChecks;
using System.Reflection;
using Microsoft.OpenApi.Models;
using Common.Logging.Correlation;

namespace Catalog.API
{
    public class Startup
    {
        public IConfiguration Configuration;

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //services.AddApiVersioning();
            services.AddApiVersioning(options => options.ReportApiVersions = true)
            .AddVersionedApiExplorer(
            options =>
            {
                options.GroupNameFormat = "'v'VVV";
                options.SubstituteApiVersionInUrl = true;
            });
            services.AddMvcCore()
                .AddCors(options =>
                {
                    options.AddPolicy("CorsPolicy", policy =>
                    {
                        policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
                    });
                }).AddApiExplorer();

            services.AddHealthChecks()
                .AddMongoDb(Configuration["DatabaseSettings:ConnectionString"], "Catalog  Mongo Db Health Check",
                    HealthStatus.Degraded);
            services.AddSwaggerGen(c => { c.SwaggerDoc("v1", new OpenApiInfo { Title = "Catalog.API", Version = "v1" }); });
            //services.AddSwaggerDocumentation();

            //DI
            services.AddAutoMapper(typeof(Startup));
            services.AddMediatR(typeof(CreateProductHandler).GetTypeInfo().Assembly);

            services.AddScoped<ICorrelationIdGenerator, CorrelationIdGenerator>();//when we add the ELK
            services.AddScoped<ICatalogContext, CatalogContext>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IBrandRepository, ProductRepository>();
            services.AddScoped<ITypesRepository, ProductRepository>();

            //Identity Server changes
            //var userPolicy = new AuthorizationPolicyBuilder()
            //    .RequireAuthenticatedUser()
            //    .Build();
            //services.AddControllers(config =>
            //{
            //    config.Filters.Add(new AuthorizeFilter(userPolicy));
            //});
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //    .AddJwtBearer(option =>
            //    {
            //        option.Authority = "https://localhost:9009";
            //        option.Audience = "Catalog";
            //    });
            //services.AddAuthorization(options =>
            //{
            //    options.AddPolicy("CanRead", policy => policy.RequireClaim("scope", "catalogapi.read"));
            //});
        }
        //public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider)
        //{
        //    var nginxPath = "/catalog";
        //    //if (env.IsEnvironment("Local"))
        //    //{
        //    //    app.UseDeveloperExceptionPage();
        //    //    app.UseSwagger();
        //    //    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog.API v1"));
        //    //}

        //    if (env.IsDevelopment())
        //    {
        //        app.UseDeveloperExceptionPage();
        //    app.UseForwardedHeaders(new ForwardedHeadersOptions
        //    {
        //        ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
        //    });

        //      //app.UseSwaggerDocumentation(nginxPath, Configuration, provider);
        //        //app.UseSwagger();
        //        //app.UseSwaggerUI(options =>
        //        //{
        //        //    foreach (var description in provider.ApiVersionDescriptions)
        //        //    {
        //        //        options.SwaggerEndpoint($"{nginxPath}/swagger/{description.GroupName}/swagger.json",
        //        //            $"Catalog API {description.GroupName.ToUpperInvariant()}");
        //        //        options.RoutePrefix = string.Empty;
        //        //    }

        //        //    options.DocumentTitle = "Catalog API Documentation";

        //        //});
        //    }

        //    app.UseHttpsRedirection();
        //    app.UseRouting();
        //    app.UseCors("CorsPolicy");
        //    app.UseAuthentication();
        //    app.UseStaticFiles();
        //    app.UseAuthorization();
        //    app.UseEndpoints(endpoints =>
        //    {
        //        endpoints.MapControllers();
        //        endpoints.MapHealthChecks("/health", new HealthCheckOptions()
        //        {
        //            Predicate = _ => true,
        //            ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
        //        });
        //    });
        //}


        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //var nginxPath = "/catalog";
            //// if (env.IsEnvironment("Local"))
            //// {
            ////     app.UseDeveloperExceptionPage();  
            ////     app.UseSwagger();
            ////     app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog.API v1"));
            //// }

            ////if (env.IsDevelopment())
            ////{
            //app.UseDeveloperExceptionPage();
            //app.UseForwardedHeaders(new ForwardedHeadersOptions
            //{
            //    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
            //});
            ////app.UseSwaggerDocumentation(nginxPath, Configuration, provider);
            //app.UseSwaggerDocumentation();
            ////app.UseSwaggerUI(options =>
            ////{
            ////    foreach (var description in provider.ApiVersionDescriptions)
            ////    {
            ////        options.SwaggerEndpoint($"{nginxPath}/swagger/{description.GroupName}/swagger.json",
            ////            $"Catalog API {description.GroupName.ToUpperInvariant()}");
            ////        options.RoutePrefix = string.Empty;
            ////    }

            ////    options.DocumentTitle = "Catalog API Documentation";

            ////});
            //// }

            //app.UseHttpsRedirection();
            //app.UseRouting();
            //app.UseCors("CorsPolicy");
            //app.UseAuthentication();
            //app.UseStaticFiles();
            //app.UseAuthorization();
            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapControllers();
            //    endpoints.MapHealthChecks("/health", new HealthCheckOptions()
            //    {
            //        Predicate = _ => true,
            //        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            //    });
            //});


            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Catalog.API v1"));

            }
            app.UseRouting();
            //app.UseAuthentication(); //need when i used identity server 
            app.UseStaticFiles();
            // app.UseAuthorization();
            app.UseCors("CorsPolicy");

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHealthChecks("/health", new HealthCheckOptions()
                {
                    Predicate = _ => true,
                    ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
                });
            });
        }
    }
}
