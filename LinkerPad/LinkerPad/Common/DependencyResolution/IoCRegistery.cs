using System.Web.Http;
using LinkerPad.Business.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;

namespace LinkerPad.Common.DependencyResolution
{
    public static class IoCRegistery
    {
        public static void Initialize()
        {
            // Create the container as usual.
            Container container = new Container();

            container.Options.DefaultScopedLifestyle = new AsyncScopedLifestyle();

            container.Register<ITokenHelper, TokenHelper>(Lifestyle.Scoped);

            // Register your types, for instance using the scoped lifestyle:
            IoC.LoadBusinessDependencyInjection(container);

            // This is an extension method from the integration package.
            container.RegisterWebApiControllers(GlobalConfiguration.Configuration);

            container.Verify();

            GlobalConfiguration.Configuration.DependencyResolver =
                new SimpleInjectorWebApiDependencyResolver(container);
        }
    }
}