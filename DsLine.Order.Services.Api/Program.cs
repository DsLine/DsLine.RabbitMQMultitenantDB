using Autofac;
using Autofac.Extensions.DependencyInjection;
using DsLine.Core.RabbitMQ;
using DsLine.Orders.Infra.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RawRabbit.Instantiation;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace DsLine.Orders.Services.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().MigrateDatabase().Run();
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

    public static class MigrationManager
    {
        public static IHost MigrateDatabase(this IHost host)
        {
            using (var scope = host.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<OrderDbContext>())
                {
                    try
                    {
                        appContext.Database.Migrate();
                    }
                    catch (Exception ex)
                    {
                        //Log errors or do anything you think it's needed
                        throw;
                    }
                }
            }

            return host;
        }
    }
}