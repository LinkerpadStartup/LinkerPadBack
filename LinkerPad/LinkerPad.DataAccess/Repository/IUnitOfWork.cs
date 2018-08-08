namespace LinkerPad.DataAccess.Repository
{
    public interface IUnitOfWork
    {
        void BeginTransaction();

        void Commit();

        void Rollback();
    }
}