using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LuckCode.IServices.Base
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        Task<TEntity> QueryByID(object objId);
        Task<TEntity> QueryByID(object objId, bool blnUseCache = false);
        Task<List<TEntity>> QueryByIDs(object[] lstIds);

        Task<int> Add(TEntity model);

        Task<bool> DeleteById(object id);

        Task<bool> Delete(TEntity model);

        Task<bool> DeleteByIds(object[] ids);

        Task<bool> Update(TEntity model);
        Task<bool> Update(TEntity entity, string strWhere);
        Task<List<TEntity>> Query(Expression<Func<TEntity, bool>> whereExpression);
    }
}
