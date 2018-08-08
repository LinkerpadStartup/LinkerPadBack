using System;
using System.Linq;

namespace LinkerPad.DataAccess.Repository
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> GetAll();

        T GetById(Guid id);

        void Create(T entity);

        void Update(T entity);

        void Delete(Guid id);
    }
}