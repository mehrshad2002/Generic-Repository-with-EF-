using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private DbGeneric _db;
        private DbSet<TEntity> _dbSet;

        public Repository(DbGeneric db)
        {
            _db = db;
            _dbSet = _db.Set<TEntity>() ;
        }


        public void Delete(TEntity entity)
        {
            if(_db.Entry(entity).State == EntityState.Detached)
            {
                _dbSet.Attach(entity);
            }
            _dbSet.Remove(entity);
        }

        public void DeleteByID(object id)
        {
            var entity = GetById(id);
            Delete(entity);
        }

        public IEnumerable<TEntity> GetAll(Expression<Func<TEntity , bool>> where = null)
        {
            IQueryable<TEntity> query = _dbSet ;

            if(where != null)
            {
                query = query.Where(where);
            }
            return query.ToList();
        }

        public TEntity GetById(object id)
        {
            return _dbSet.Find(id);
        }

        public void Insert(TEntity entity)
        {
            _dbSet.Add(entity);
        }

        public void Update(TEntity entity)
        {
            _dbSet.Attach(entity);
            _db.Entry(entity).State = EntityState.Modified;
        }
    }
}