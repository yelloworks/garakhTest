using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace garakhTest
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            using (var context = new DbEntities())
            {
                Student user = new Student() { Name = "User2", Group = "Gr2"};
                //var tmp = context.GetUser(2);
                //var value = tmp.FirstOrDefault();
                //var lst = tmp.ToList();
                var tmp = context.GetData();
                context.SaveChanges();
            }
        }
    }
}
