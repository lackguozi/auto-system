﻿using LuckCode.IRepository.Base;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace LuckCode.Repository.Base
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, new()
    {
        public BaseRepository(IUnitOfWorkManger unitOfWorkManger)
        {
            _dbBase = unitOfWorkManger.GetDbClient();
            this.unitOfWorkManger = unitOfWorkManger;
        }

        private readonly SqlSugarScope _dbBase;
        private readonly IUnitOfWorkManger unitOfWorkManger;

        private ISqlSugarClient _db
        {
            get
            {
                ISqlSugarClient client = _dbBase;
                //如果实体类有租户属性，则换连接 
                var typeAtt = typeof(TEntity).GetCustomAttribute<TenantAttribute>();
                if(typeAtt != null)
                {
                    client = _dbBase.AsTenant().GetConnectionScope(typeAtt.configId.ToString().ToLower());
                }
                return client;
            }

        }
        public ISqlSugarClient DbContext()
        {
            return _db;
        }
        public async Task<int> Add(TEntity model)
        {
            var insert = _db.Insertable(model);
            return await insert.ExecuteCommandAsync();
        }

        public async Task<bool> Delete(TEntity model)
        {
            return await _db.Deleteable(model).ExecuteCommandHasChangeAsync();
        }

        public async Task<bool> DeleteById(object id)
        {
            return await _db.Deleteable<TEntity>().In(id).ExecuteCommandHasChangeAsync();
        }

        public async Task<bool> DeleteByIds<T>(T[] ids)
        {
            return await _db.Deleteable<TEntity>().In(ids).ExecuteCommandHasChangeAsync();
        }
        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression)
        {
            return await _db.Queryable<TEntity>().WhereIF(whereExpression != null, whereExpression).ToListAsync();
        }
        public async Task<TEntity> QueryByID(object objId)
        {
            return await _db.Queryable<TEntity>().In(objId).SingleAsync();
        }

        public async Task<TEntity> QueryByID(object objId, bool blnUseCache = false)
        {
            return await _db.Queryable<TEntity>().WithCacheIF(blnUseCache, 10).In(objId).SingleAsync();
        }

        public async Task<List<TEntity>> QueryByIDs<T>(T[] lstIds)
        {
            return await _db.Queryable<TEntity>().In(lstIds).ToListAsync();
        }

        public async Task<bool> Update(TEntity model)
        {
            return await _db.Updateable(model).ExecuteCommandHasChangeAsync();
        }

        public async Task<bool> Update(TEntity entity, string strWhere)
        {
            return await _db.Updateable(entity).Where(strWhere).ExecuteCommandHasChangeAsync();
        }
        /// <summary>
        /// 查询所有数据
        /// </summary>
        /// <returns></returns>
        public async Task<List<TEntity>> Query()
        {
            return await _db.Queryable<TEntity>().ToListAsync();
        }
    }
}
