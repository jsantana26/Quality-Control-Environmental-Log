﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace QCEL
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
	        var settings = config.Formatters.JsonFormatter.SerializerSettings;
			settings.ContractResolver = new CamelCasePropertyNamesContractResolver();
			settings.Formatting = Formatting.Indented;

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
				name: "GetDescriptionApi",
				routeTemplate: "api/{controller}/{location}",
				new { controller = "SampleLocations", action = "GetDescription", id = UrlParameter.Optional }
            );


			config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
