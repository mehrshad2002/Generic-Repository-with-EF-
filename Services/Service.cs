using System.Linq.Expressions;
using Repositories;

namespace Services
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {

        private IRepository<TEntity> repositoryy;
        public Service(DbGeneric db )
        {
            repositoryy = new Repository<TEntity>( db );
        }
        public void Delete(TEntity entity)
        {
            repositoryy.Delete(entity);
        }

        public void DeleteByID(object id)
        {
            repositoryy.DeleteByID(id);
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity, bool>> where = null)
        {
            return repositoryy.GetAll(where);
        }

        public TEntity GetById(object id)
        {
            return repositoryy.GetById(id);
        }

        public void Insert(TEntity entity)
        {
            repositoryy.Insert(entity);
        }

        public void Update(TEntity entity)
        {
            repositoryy.Update(entity);
        }
    }
}