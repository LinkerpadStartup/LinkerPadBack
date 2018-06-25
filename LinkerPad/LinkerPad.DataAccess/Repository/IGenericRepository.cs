using System;
using System.Linq;
using System.Linq.Expressions;

namespace LinkerPad.DataAccess.Repository
{

    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);
        Tuple<bool, TEntity> Exists(TEntity entity);
        TEntity Add(TEntity entity);
        void Delete(TEntity entity);
        void BaseDelete(TEntity entity);
        void Edit(TEntity entity);
        void Save();
    }
}
