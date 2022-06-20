using LuckCode.IRepository.Base;
using LuckCode.IServices.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LuckCode.Services.Base
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            this.baseRepository = baseRepository;
        }

        public async Task<int> Add(TEntity model)
        {
            return await baseRepository.Add(model);
        }

        public async Task<bool> Delete(TEntity model)
        {
            return await baseRepository.Delete(model);
        }

        public async Task<bool> DeleteById(object id)
        {
            return await baseRepository.DeleteById(id);
        }

        public async Task<bool> DeleteByIds(object[] ids)
        {
            return await baseRepository.DeleteByIds(ids);
        }

        public async Task<TEntity> QueryByID(object objId)
        {
            return await baseRepository.QueryByID(objId);
        }

        public async Task<TEntity> QueryByID(object objId, bool blnUseCache = false)
        {
           return await baseRepository.QueryByID(objId, blnUseCache);
        }

        public async Task<List<TEntity>> QueryByIDs(object[] lstIds)
        {
            return await baseRepository.QueryByIDs(lstIds);
        }

        public async Task<bool> Update(TEntity model)
        {
            return await baseRepository.Update(model);
        }

        public async Task<bool> Update(TEntity entity, string strWhere)
        {
            return await baseRepository.Update(entity, strWhere);
        }
        public async Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression)
        {
            return await baseRepository.Query(whereExpression);
        }
    }
}
