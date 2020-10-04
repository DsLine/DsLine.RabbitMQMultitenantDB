using DShop.Common.RestEase;
using DShop.CrossCutting.MultiTenant;
using DsLine.Core.RabbitMQ;
using DsLine.Core.Services.Api.Middleware;
using DsLine.Orders.Infra.Repository;
using DsLine.Orders.Services.Api.ExternalServices.Stock;
using DsLine.Orders.Services.Api.Messages.Commands;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RawRabbit;
using System.ComponentModel;

namespace DsLine.Orders.Services.Api
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
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();
            services.AddDbContext<OrderDbContext>(ServiceLifetime.Scoped);
            services.RegisterServiceForwarder<IStockItemServices>("stock-service");
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [System.Obsolete]
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Microsoft.AspNetCore.Hosting.IApplicationLifetime applicationLifetime)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }




            app.UseTenantMiddleware();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseRabbitMq("tenant1");
            app.UseRabbitMq("tenant2");
            applicationLifetime.ApplicationStopped.Register(() =>
            {

                Container.Dispose();
            });
        }
    }
}
