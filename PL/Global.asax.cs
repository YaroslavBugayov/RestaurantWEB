using Ninject.Modules;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using BLL.Infrastructure;
using Ninject.Web.Mvc;

namespace PL
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            IKernel ninjectKernel = new StandardKernel(new NinjectBindings());
            DependencyResolver.SetResolver(new NinjectDependencyResolver(ninjectKernel));
            

        }
    }
}
