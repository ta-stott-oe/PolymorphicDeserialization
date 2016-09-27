using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace PolymorphicDeserializationExample
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

            // Add a custom converter for Vehicles
            foreach (var formatter in GlobalConfiguration.Configuration.Formatters)
            {
                var jsonFormatter = formatter as System.Net.Http.Formatting.JsonMediaTypeFormatter;
                if (jsonFormatter == null)
                    continue;

                jsonFormatter.SerializerSettings.Converters.Add(new Models.VehicleConverter());
            }
        }
    }
}
