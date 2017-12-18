using EmployeeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace DemoWepApi
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Web API configuration and services
			
			
			// Web API routes
			config.MapHttpAttributeRoutes();

			config.Routes.MapHttpRoute(
				name: "Employee",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { controller = "Employee", action = "Get", id = RouteParameter.Optional }
			);
			config.Formatters.Remove(config.Formatters.XmlFormatter);
			config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
			config.Filters.Add(new BasicAuthenticationAttribute());
		}
	}
}
