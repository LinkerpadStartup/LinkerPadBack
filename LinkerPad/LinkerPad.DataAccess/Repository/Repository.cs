using System;
using System.Linq;
using NHibernate;

namespace LinkerPad.DataAccess.Repository
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        private readonly UnitOfWork _unitOfWork;

        protected Repository(IUnitOfWork unitOfWork)
        {
            _unitOfWork = (UnitOfWork)unitOfWork;
        }

        protected ISession Session => _unitOfWork.Session;

        public virtual IQueryable<T> GetAll()
        {
            return Session.Query<T>();
        }

        public virtual T GetById(Guid id)
        {
            return Session.Get<T>(id);
        }

        public virtual void Create(T entity)
        {
            Session.Save(entity);
        }

        public virtual void Update(T entity)
        {
            Session.Update(entity);
        }

        public void Delete(Guid id)
        {
            Session.Delete(Session.Load<T>(id));
        }
    }
}
