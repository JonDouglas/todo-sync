using Microsoft.Practices.Unity;
using System.Web.Http;
using Todo_Sync.API.Data.Repositories;
using Unity.WebApi;

namespace Todo_Sync.API
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<ITodoRepository, TodoRepository>();
            
            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            
            GlobalConfiguration.Configuration.DependencyResolver = new UnityDependencyResolver(container);
        }
    }
}