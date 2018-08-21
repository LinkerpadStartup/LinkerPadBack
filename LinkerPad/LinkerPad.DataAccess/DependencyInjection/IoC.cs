using LinkerPad.DataAccess.Entity;
using LinkerPad.DataAccess.EntityInterface;
using LinkerPad.DataAccess.Repository;
using SimpleInjector;

namespace LinkerPad.DataAccess.DependencyInjection
{
    public class IoC
    {
        public static void LoadDataAccessDependencyInjection(Container container)
        {
            container.Register<IUnitOfWork, UnitOfWork>(Lifestyle.Scoped);

            container.Register<IUserRepository, UserRepository>(Lifestyle.Scoped);
            container.Register<IProjectRepository, ProjectRepository>(Lifestyle.Scoped);
            container.Register<IProjectTeamRepository, ProjectTeamRepository>(Lifestyle.Scoped);
            container.Register<IDailyTaskRepository, DailyTaskRepository>(Lifestyle.Scoped);
        }
    }
}
