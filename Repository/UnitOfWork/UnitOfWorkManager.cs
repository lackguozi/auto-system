using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckCode.Repository
{
    public class UnitOfWorkManager : IUnitOfWorkManger
    {
        private readonly ISqlSugarClient sqlSugarClient;

        public UnitOfWorkManager(ISqlSugarClient sqlSugarClient)
        {
            this.sqlSugarClient = sqlSugarClient;
        }
        private int tranCount { get; set; }
        public int TranCount => tranCount;

        public void BeginTran()
        {
            lock (this)
            {
                tranCount++;
                GetDbClient().BeginTran();
            }
        }

        public void CommitTran()
        {
           lock (this)
            {
                tranCount--;
                if(tranCount == 0)
                {
                    try
                    {
                        GetDbClient().CommitTran();

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        GetDbClient().RollbackTran();
                    }
                }
            }
        }

        public UnitOfWork CreateUnitOfWork()
        {
            var uow = new UnitOfWork();
            uow.IsTran = true;
            uow.Db = sqlSugarClient;
            uow.Tenant = sqlSugarClient.AsTenant();
            uow.Db.Ado.Open();
            uow.Tenant.BeginTran();
            return uow;
        }

        public SqlSugarScope GetDbClient()
        {
            return sqlSugarClient as SqlSugarScope;
        }

        public void RollbackTran()
        {
            lock (this)
            {
                tranCount--;
                GetDbClient().RollbackTran();
            }
        }
    }
}
