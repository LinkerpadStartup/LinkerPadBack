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
            container.Register<IProjectLogic, ProjectLogic>(Lifestyle.Scoped);
            container.Register<IProjectTeamLogic, ProjectTeamLogic>(Lifestyle.Scoped);
            container.Register<IDailyActivityLogic, DailyActivityLogic>(Lifestyle.Scoped);
            container.Register<IMaterialLogic, MaterialLogic>(Lifestyle.Scoped);
            container.Register<IEquipmentLogic, EquipmentLogic>(Lifestyle.Scoped);
            container.Register<IConfirmationLogic, ConfirmationLogic>(Lifestyle.Scoped);
        }
    }
}
