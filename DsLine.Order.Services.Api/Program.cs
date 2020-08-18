using Autofac;
using Autofac.Extensions.DependencyInjection;
using DsLine.Core.RabbitMQ;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using RawRabbit.Instantiation;
using System.Collections.Generic;
using System.Reflection;

namespace DsLine.Orders.Services.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
          Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())
            .ConfigureContainer<ContainerBuilder>(builder =>
            {
                builder.RegisterAssemblyTypes(Assembly.GetEntryAssembly())
                    .AsImplementedInterfaces();

                // builder.RegisterType<OrderDbContext>().AsSelf();
                builder.AddRabbitMq();
                builder.Register(context =>
                {
                    List<RawRabbit.IBusClient> busClients = new List<RawRabbit.IBusClient>();
                    context.Resolve<List<IInstanceFactory>>().ForEach(x => busClients.Add(x.Create()));
                    return busClients;
                });
            })
              .ConfigureWebHostDefaults(webBuilder =>
              {
                  webBuilder.UseStartup<Startup>();
              });
    }
}