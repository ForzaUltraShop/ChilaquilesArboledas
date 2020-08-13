namespace ChilaquilesArboledas
{
    using Microsoft.AspNet.FriendlyUrls;
    using System;
    using System.Web;
    using System.Web.Routing;

    public class Global : HttpApplication //,IContainerProviderAccessor
    {
        // Provider that holds the application container.
        //static IContainerProvider _containerProvider;

        //Instance property that will be used by Autofac HttpModules to resolve and inject dependencies. 
        //public IContainerProvider ContainerProvider
        //{
        //    get { return _containerProvider; }
        //}

        public static void RegisterRoutes(RouteCollection routes)
        {
            var settings = new FriendlyUrlSettings();
            routes.EnableFriendlyUrls(settings);
        }

        protected void Application_Start(object sender, EventArgs e)
        {
            // Build up your application container and register your dependencies.
            //var builder = new ContainerBuilder();

            //Logic
            //builder.RegisterType<CategoriesLogic>().As<ICategoriesLogic>();
            //builder.RegisterType<DishesLogic>().As<IDishesLogic>();
            //builder.RegisterType<CustomersLogic>().As<ICustomerLogic>();

            //DataLayer
            //builder.RegisterType<CategoriesDataLayer>().As<ICategoriesDataLayer>();
            //builder.RegisterType<DishesDataLayer>().As<IDishesDataLayer>();
            //builder.RegisterType<CustomerDataLayer>().As<ICustomerDataLayer>();

            // Once you're done registering things, set the container
            // provider up with your registrations.
            //_containerProvider = new ContainerProvider(builder.Build());

            // Standard web forms startup.
            RegisterRoutes(RouteTable.Routes);
        }
    }
}