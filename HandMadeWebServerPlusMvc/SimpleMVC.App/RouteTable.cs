﻿namespace SimpleMVC.App
{
    using SimpleHttpServer.Enums;
    using SimpleHttpServer.Models;
    using MVC.Routers;
    using System.Collections.Generic;

    public static class RouteTable
    {
        public static IEnumerable<Route> Routes
        {
            get
            {
                return new Route[]
                {
                    new Route
                    {
                        Name = "Controller/Action/GET",
                        Method = RequestMethod.GET,
                        UrlRegex = @"^/(.+)/(.+)",
                        Callable =new ControllerRouter().Handle
                    },
                    new Route
                    {
                        Name = "Controller/Action/POST",
                        Method = RequestMethod.POST,
                        UrlRegex = @"^/(.+)/(.+)",
                        Callable =new ControllerRouter().Handle
                    }
                };
            }
        }
    }
}
