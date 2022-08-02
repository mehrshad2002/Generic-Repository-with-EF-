using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        TEntity GetById(object id);
        void Delete(TEntity entity);
        void DeleteByID(object id );
        IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> where = null);
    }
}
