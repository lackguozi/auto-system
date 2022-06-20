using LuckCode.Common;
using LuckCode.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace auto_system.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddCustomizedConfigurationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddModules(configuration);
            var servicesProvider = services.BuildServiceProvider();
            var initalizerServices = servicesProvider.GetServices<IModuleInitializer>();
            Console.WriteLine($"服务的数量{initalizerServices.Count()} 个");
            foreach (var service in initalizerServices)
            {
                service.ConfigurationServices(services, configuration);
            }
        }
        public static void AddModules(this IServiceCollection services, IConfiguration configuration)
        {
            var modules = configuration.GetSection("Modules").Get<List<ModuleInfo>>();
            
            foreach (var module in modules)
            {
                module.Assembly = Assembly.Load(new AssemblyName(module.Id));
                var moduleType = module.Assembly.GetTypes().FirstOrDefault(a => typeof(IModuleInitializer).IsAssignableFrom(a) && typeof(IModuleInitializer) != a);
                if (moduleType != null)
                {
                    services.AddSingleton(typeof(IModuleInitializer), moduleType);
                }
            }
        }
    }
}
