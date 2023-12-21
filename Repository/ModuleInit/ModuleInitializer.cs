using LuckCode.Common;
using LuckCode.IRepository;
using LuckCode.IRepository.Base;
using LuckCode.Model;
using LuckCode.Repository.Base;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckCode.Repository.ModuleInit
{
    public class ModuleInitializer : IModuleInitializer
    {
        public void ConfigurationServices(IServiceCollection services, IConfiguration configuration)
        {
            //工作单元 
            services.AddSingleton<IUnitOfWorkManger,UnitOfWorkManager>();
            services.AddScoped(typeof( IBaseRepository<>), typeof(BaseRepository<>));
            services.AddTransient<IMenuRepository, MenuRepository>();

            //services.AddTransient(typeof(IRepository<>), typeof(BaseRepository<>));
        }
    }
}
