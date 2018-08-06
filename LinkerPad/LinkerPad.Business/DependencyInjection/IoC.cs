using LinkerPad.Business.BusinessLogic;
using LinkerPad.Business.BusinessLogicInterface;
using SimpleInjector;

namespace LinkerPad.Business.DependencyInjection
{
    public class IoC
    {
        public static void LoadBusinessDependencyInjection(Container container)
        {
            DataAccess.DependencyInjection.IoC.LoadDataAccessDependencyInjection(container);

            container.Register<IAccountLogic, AccountLogic>(Lifestyle.Scoped);
        }
    }
}
