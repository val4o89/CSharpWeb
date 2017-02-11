using SimpleHttpServer.Core;
using SimpleHttpServer.Enums;
using SimpleHttpServer.Models;
using System;
using System.Collections.Generic;
using System.IO;

namespace FirstServerTest
{
    public class Startup
    {
        public static void Main(string[] args)
        {
            var routes = new List<Route>()
            {
                new Route()
                {
                    Name = "CssRoutes",
                    Method = RequestMethod.GET,
                    UrlRegex = "^/css/.*$",
                    Callable = (request) =>
                    {
                        var fileName = request.Url.Substring(request.Url.LastIndexOf("/") + 1);
                        var response = new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.OK,
                            ContentAsUTF8 = File.ReadAllText($"../../content/css/{fileName}")
                        };
                        response.Header.ContentType = "text/css";
                        return response;
                    }
                },
                new Route()
                {
                    Name = "JavaScriptRoutes",
                    Method = RequestMethod.GET,
                    UrlRegex = "^/javascript/.*$",
                    Callable = (request) =>
                    {
                        var fileName = request.Url.Substring(request.Url.LastIndexOf("/") + 1);
                        var response = new HttpResponse()
                        {
                            StatusCode = SimpleHttpServer.Enums.ResponseStatusCode.OK,
                            ContentAsUTF8 = File.ReadAllText($"../../content/javascript/{fileName}")
                        };
                        response.Header.ContentType = "application/x-javascript";
                        return response;
                    }
                },
                new Route()
                {
                    Name = "ImagesRoute",
                    Method = RequestMethod.GET,
                    UrlRegex = @"^\/images\/.*",
                    Callable = (request) =>
                    {
                        string fileName = request.Url.Substring(request.Url.LastIndexOf("/"));
                        var response = new HttpResponse()
                        {
                            
                            StatusCode = ResponseStatusCode.OK,
                            Content = File.ReadAllBytes($"../../content/images/{fileName}")
                        };
                        response.Header.ContentType = "image/jpeg";
                        response.Header.ContentLength = response.Content.Length.ToString();
                        return response;
                    }
                },
                                new Route()
                {
                    Name = "HtmlsRoute",
                    Method = RequestMethod.GET,
                    UrlRegex = @"^/.+\.html$",
                    Callable = (request) =>
                    {
                        var fileName = request.Url.Substring(request.Url.LastIndexOf("/"));
                        return new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.OK,
                            ContentAsUTF8 = File.ReadAllText($"../../content/{fileName}")
                        };
                    }
                },
                new Route()
                {
                    Name = "HtmlsRoute",
                    Method = RequestMethod.POST,
                    UrlRegex = @"^/.+\.html$",
                    Callable = (request) =>
                    {
                        var fileName = request.Url.Substring(request.Url.LastIndexOf("/"));
                        return new HttpResponse()
                        {
                            StatusCode = ResponseStatusCode.OK,
                            ContentAsUTF8 = File.ReadAllText($"../../content/{fileName}")
                        };
                    }
                }
            };

            var server = new HttpServer(80, routes);

            server.Listen();
        }
    }
}
