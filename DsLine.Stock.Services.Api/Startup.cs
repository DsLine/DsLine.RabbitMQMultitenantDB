using Autofac;
using DShop.CrossCutting.MultiTenant;
using DsLine.Core.RabbitMQ;
using DsLine.Core.Services.Api.Middleware;
using DsLine.Stock.Infra.Repository;
using DsLine.Stock.Services.Api.Messages.Commands;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DsLine.Stock.Services.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public IContainer Container { get; private set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {


            services.AddScoped<ITenant, Tenant>();
            services.AddScoped<IItemRepository, ItemRepository>();
            services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDbContext<StockDbContext>(ServiceLifetime.Scoped);
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Microsoft.AspNetCore.Hosting.IApplicationLifetime applicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseTenantMiddleware();

            app.UseRabbitMq("tenant1")
                   .SubscribeEvent<UpdateStockEvent>();

            app.UseRabbitMq("tenant2")
             .SubscribeEvent<UpdateStockEvent>();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            applicationLifetime.ApplicationStopped.Register(() =>
            {

                Container.Dispose();
            });
        }
    }
}
