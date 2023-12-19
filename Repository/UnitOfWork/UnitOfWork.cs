using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LuckCode.Repository.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {
        public ISqlSugarClient Db { get; internal set; }
        public ITenant Tenant { get; internal set; }
        /// <summary>
        /// 是否是事务
        /// </summary>
        public bool IsTran;
        /// <summary>
        /// 是否提交
        /// </summary>
        public bool IsCommit;
        /// <summary>
        /// 是否关闭
        /// </summary>
        public bool IsClose;
        public bool Commit()
        {
            if (IsTran && !IsCommit)
            {
                Tenant.CommitTran();
                IsCommit = true;
            }
            if (Db.Ado.Transaction == null && !IsClose)
            {
                Db.Close();
                IsClose = true;
            }
            return IsCommit;
        }
        public void Dispose()
        {
            if (IsTran && !IsCommit)
            {
                //Logger.LogDebug("UnitOfWork RollbackTran");
                Tenant.RollbackTran();
            }

            if (Db.Ado.Transaction != null || IsClose)
                return;
            Db.Close();
        }
    }
}
