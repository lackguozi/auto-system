
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LuckCode.Common
{
    public interface IModuleInitializer
    {
        public void ConfigurationServices( IServiceCollection services,IConfiguration configuration);
    }
}