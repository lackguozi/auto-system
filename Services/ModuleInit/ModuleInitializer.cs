using LuckCode.Common;
using LuckCode.IServices;
using LuckCode.IServices.Base;
using LuckCode.Services.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckCode.Services.ModuleInit
{
    public class ModuleInitializer: IModuleInitializer
    {
        public void ConfigurationServices(IServiceCollection services, IConfiguration configuration)
        {
            //Console.WriteLine("注册服务");
            services.AddTransient(typeof(IBaseService<>), typeof(BaseService<>));
            //services.AddTransient<IDepartmentService,DepartmentSevice>();
            services.AddTransient<IUserService,UserService>();
        }
    }
}
