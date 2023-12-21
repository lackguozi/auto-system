using LuckCode.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckCode.Extensions
{
    public static class SqlsugarSetup
    {
        public static void AddSqlsugarSetup(this IServiceCollection services, IConfiguration configuration,
    string dbName = "db_master")
        {
            var dbConfigs = configuration.GetSection("DbSetting").Get<List<DbConfig>>();
            var connectionConfigs = new List<ConnectionConfig>();
            dbConfigs.ForEach(a =>
            {
                var config = new ConnectionConfig()
                {
                    ConfigId = a.ConnId.ToLower(),
                    DbType = (DbType)a.DbType,
                    ConnectionString = a.Connection,
                    IsAutoCloseConnection = true,
                };
                if (a.Enabled)
                {
                    connectionConfigs.Add(config);
                }

            });
            SqlSugarScope sqlSugar = new SqlSugarScope(connectionConfigs,
                db =>
                {
                    //单例参数配置，所有上下文生效
                    db.Aop.OnLogExecuting = (sql, pars) =>
                        {
                            Console.WriteLine(sql, pars);//输出sql
                        };
                });
            services.AddSingleton<ISqlSugarClient>(sqlSugar);//这边是SqlSugarScope用AddSingleton
        }
    }
}
