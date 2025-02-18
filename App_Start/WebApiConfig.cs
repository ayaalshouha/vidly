using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace vidly
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            
            // using camel notation converter 
            // JSON does NOT represent transfer object's properties in camel case 
            
            var settings = config.Formatters.JsonFormatter.SerializerSettings;
            settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            settings.Formatting= Newtonsoft.Json.Formatting.Indented;
            
            config.MapHttpAttributeRoutes();
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
