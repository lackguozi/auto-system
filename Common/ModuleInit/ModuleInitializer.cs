using LuckCode.Common.Helper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckCode.Common.ModuleInit
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigurationServices(IServiceCollection services, IConfiguration configuration)
        {
            Console.WriteLine("注册Jwtservice");
            services.AddTransient<IJwtHelper, JwtHelper>();
           
        }
    }
}
