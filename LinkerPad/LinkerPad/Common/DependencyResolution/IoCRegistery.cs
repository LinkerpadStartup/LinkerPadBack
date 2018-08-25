using System.Reflection;
using System.Web.Http;
using System.Web.Mvc;
using LinkerPad.Business.DependencyInjection;
using SimpleInjector;
using SimpleInjector.Integration.Web;
using SimpleInjector.Integration.Web.Mvc;
using SimpleInjector.Integration.WebApi;
using SimpleInjector.Lifestyles;

namespace LinkerPad.Common.DependencyResolution
{
    public static class IoCRegistery
    {
        public static void InitializeWebApi()
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

        public static void InitializeMvc()
        {
            // Create the container as usual.
            Container container = new Container();

            container.Options.DefaultScopedLifestyle = new WebRequestLifestyle();

            container.Register<ITokenHelper, TokenHelper>(Lifestyle.Scoped);

            // Register your types, for instance using the scoped lifestyle:
            IoC.LoadBusinessDependencyInjection(container);

            // This is an extension method from the integration package.
            container.RegisterMvcControllers(Assembly.GetExecutingAssembly());

            container.Verify();

            DependencyResolver.SetResolver(new SimpleInjectorDependencyResolver(container));
        }


    }
}