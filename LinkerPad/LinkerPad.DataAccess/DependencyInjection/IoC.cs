using LinkerPad.DataAccess.Entity;
using LinkerPad.DataAccess.EntityInterface;
using SimpleInjector;

namespace LinkerPad.DataAccess.DependencyInjection
{
    public class IoC
    {
        public static void LoadDataAccessDependencyInjection(Container container)
        {
            container.Register<IUserRepository, UserRepository>(Lifestyle.Scoped);
        }
    }
}
