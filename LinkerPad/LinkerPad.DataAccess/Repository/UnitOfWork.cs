using System.Configuration;
using FluentNHibernate.Cfg;
using FluentNHibernate.Cfg.Db;
using LinkerPad.DataAccess.Mapping;
using NHibernate;
using NHibernate.Tool.hbm2ddl;

namespace LinkerPad.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private static readonly ISessionFactory SessionFactory;

        private ITransaction _transaction;

        public ISession Session { get; private set; }

        static UnitOfWork()
        {
            // Initialise singleton instance of ISessionFactory, static constructors are only executed once during the 
            // application lifetime - the first time the UnitOfWork class is used
            SessionFactory = Fluently.Configure()
                .Database(MsSqlConfiguration.MsSql2012.ConnectionString(ConfigurationManager.ConnectionStrings["LinkerPadDb"].ConnectionString))
                .Mappings(MapConfiguration.BindingMappedModels)
                .ExposeConfiguration(config => new SchemaUpdate(config).Execute(false, true))
                .BuildSessionFactory();
        }

        public UnitOfWork()
        {
            Session = SessionFactory.OpenSession();
        }

        public void BeginTransaction()
        {
            _transaction = Session.BeginTransaction();
        }

        public void Commit()
        {
            try
            {
                // commit transaction if there is one active
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Commit();
            }
            catch
            {
                // rollback if there was an exception
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Rollback();

                throw;
            }
            finally
            {
                Session.Dispose();
            }
        }

        public void Rollback()
        {
            try
            {
                if (_transaction != null && _transaction.IsActive)
                    _transaction.Rollback();
            }
            finally
            {
                Session.Dispose();
            }
        }
    }
}
