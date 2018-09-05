using LibraryWeb.Infrastructure;
using LibraryWeb.Services;
using System.Web.Mvc;
using Unity;

namespace LibraryWeb.App_Start
{
    public static class IocConfigurator
    {
        public static void ConfigureIocContainer()
        {
            IUnityContainer container = new UnityContainer();
 
            registerServices(container);

            DependencyResolver.SetResolver(new LibraryDependencyResolver(container));
        }

        private static void registerServices(IUnityContainer container)
        {
            container.RegisterType<IDeserialize, Deserialize>();
            container.RegisterType<ISerialize, Serialize>();
            container.RegisterType<IPathProvider, PathProvider>();
        }
    }
}