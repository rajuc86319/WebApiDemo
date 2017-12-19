using DemoWepApi.Custom;
using EmployeeService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Dispatcher;

namespace DemoWepApi
{
	public static class WebApiConfig
	{
		public static void Register(HttpConfiguration config)
		{
			// Web API configuration and services


			// Web API routes that enables the Attribute routing 
			config.MapHttpAttributeRoutes();

			//Conventional based routing
			config.Routes.MapHttpRoute(
				name: "Default route",
				routeTemplate: "api/{controller}/{id}",
				defaults: new { id = RouteParameter.Optional }
			);

			config.Routes.MapHttpRoute(
				name: "Version1",
				routeTemplate: "api/v1/Students/{id}",
				defaults: new { id = RouteParameter.Optional, controller = "StudentsV1" }
			);
			config.Routes.MapHttpRoute(
				name: "Version2",
				routeTemplate: "api/v2/Students/{id}",
				defaults: new { id = RouteParameter.Optional, controller = "StudentsV2" }
			);

			//replaces the defalut controller selecter to our Custom controler selector
			config.Services.Replace(typeof(IHttpControllerSelector),new CustomControllerSelector(config));

			//Removing XML formatter
			config.Formatters.Remove(config.Formatters.XmlFormatter);
			
			//appliying some serializer settings to the Json formatter
			config.Formatters.JsonFormatter.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;

			//config.Filters.Add(new BasicAuthenticationAttribute());
		}
	}
}
