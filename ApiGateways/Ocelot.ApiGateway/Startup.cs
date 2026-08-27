
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Ocelot.Cache.CacheManager;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Common.Logging;
using Ocelot.Provider.Kubernetes;
using Common.Logging.Correlation;

namespace Ocelot.ApiGateway
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICorrelationIdGenerator, CorrelationIdGenerator>();//when we add the ELK
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    policy => { policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin(); });
            });
            //var authScheme = "EShoppingGatewayAuthScheme";
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //.AddJwtBearer(authScheme, options =>
            //{
            //    options.Authority = "https://localhost:9009";
            //    options.Audience = "EShoppingGateway";
            //});
                 //.AddJwtBearer(options =>
                 //{
                 //    options.Authority = "https://localhost:9009";
                 //    options.Audience = "EShoppingGateway";
                 //});
            services.AddOcelot()
                //.AddKubernetes()
                .AddCacheManager(o => o.WithDictionaryHandle());
        }

        public async void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.AddCorrelationIdMiddleware();//when we add the ELK
            app.UseRouting();
            app.UseCors("CorsPolicy");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapGet("/", async context => { await context.Response.WriteAsync("Hello Ocelot"); });
            });
            await app.UseOcelot();
        }
    }
}
