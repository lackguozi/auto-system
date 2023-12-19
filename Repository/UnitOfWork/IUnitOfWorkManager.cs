using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckCode.Repository.UnitOfWork
{
    public interface IUnitOfWorkManger
    {
        void BeginTran();
        void CommitTran();
        void RollbackTran();
        SqlSugarScope GetDbClient();
        int TranCount { get; }
        UnitOfWork CreateUnitOfWork();
    }
}
