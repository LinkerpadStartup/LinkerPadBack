using System;
using System.Data.Entity;
using System.Linq;

namespace LinkerPad.DataAccess.Repository
{
    public abstract class GenericRepository<TContext, TEntity> :
            IGenericRepository<TEntity>
            where TEntity : class
            where TContext : DbContext, new()
    {

        private TContext _entities = new TContext();
        public TContext Context
        {
            get => _entities;
            set => _entities = value;
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return _entities.Set<TEntity>();
        }

        public IQueryable<TEntity> FindBy(System.Linq.Expressions.Expression<Func<TEntity, bool>> predicate)
        {
            return _entities.Set<TEntity>().Where(predicate);
        }

        public virtual TEntity Add(TEntity entity)
        {
            return _entities.Set<TEntity>().Add(entity);
        }

        public virtual void Delete(TEntity entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        public virtual void BaseDelete(TEntity entity)
        {
            _entities.Set<TEntity>().Remove(entity);
        }

        public virtual void Edit(TEntity entity)
        {
            _entities.Entry(entity).State = EntityState.Modified;
        }

        public virtual void Save()
        {
            _entities.SaveChanges();
        }

        public Tuple<bool, TEntity> Exists(TEntity entity)
        {
            Tuple<bool, TEntity> t = new Tuple<bool, TEntity>(_entities.Set<TEntity>().Any(), entity);
            return t;
        }
    }
}
