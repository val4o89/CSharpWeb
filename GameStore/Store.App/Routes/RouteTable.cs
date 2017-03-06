namespace Store.App.Routes
{
    using SimpleHttpServer.Enums;
    using SimpleHttpServer.Models;
    using SimpleMVC.Routers;
    using System.Collections.Generic;
    using System.IO;

    public static class RouteTable
    {
        public static IEnumerable<Route> Routes
        {
            get
            {
                return new Route[]
                {
                    new Route()
                    {
                        Name = "Bootstrap JS",
                        Method = RequestMethod.GET,
                        UrlRegex = @"^/js/bootstrap.min.js$",
                        Callable = (request) =>
                        {
                            var response = new HttpResponse()
                            {
                                StatusCode = ResponseStatusCode.Ok,
                                ContentAsUTF8 = File.ReadAllText("../../content/js/bootstrap.min.js")
                            };
                            response.Header.ContentType = "application/x-javascript";
                            return response;
                        }
                    },
                    new Route()
                    {
                        Name = "JQuery",
                        Method = RequestMethod.GET,
                        UrlRegex = "^/scripts/jquery-3.1.1.min.js$",
                        Callable = (request) =>
                        {
                            var response = new HttpResponse()
                            {
                                StatusCode = ResponseStatusCode.Ok,
                                ContentAsUTF8 = File.ReadAllText("../../content/scripts/jquery-3.1.1.min.js")
                            };
                            response.Header.ContentType = "application/x-javascript";
                            return response;
                        }
                    },
                    new Route()
                    {
                        Name = "CSS",
                        Method = RequestMethod.GET,
                        UrlRegex = @"^.*?\.css$",
                        Callable = (request) =>
                        {
                            var fileAndPathName = request.Url.Remove(0,1);
                            fileAndPathName = fileAndPathName.Substring(fileAndPathName.IndexOf('/') + 1);
                            var response = new HttpResponse()
                            {
                                StatusCode = ResponseStatusCode.Ok,
                                ContentAsUTF8 = File.ReadAllText($"../../content/{fileAndPathName}")
                            };
                            response.Header.ContentType = "text/css";
                            return response;
                        }
                    },
                    //new Route()
                    //{
                    //    Name = "Images",
                    //    Method = RequestMethod.GET,
                    //    UrlRegex = @"^/images/.*$",
                    //    Callable = (request) =>
                    //    {
                    //        var fileName = request.Url.Substring(request.Url.LastIndexOf('/') + 1);
                    //        var response = new HttpResponse()
                    //        {
                    //            StatusCode = ResponseStatusCode.Ok,
                    //            Content = File.ReadAllBytes($"../../content/images/{fileName}"),

                    //        };
                    //        response.Header.ContentLength = response.Content.Length.ToString();
                    //        response.Header.ContentType = "image/jpeg";
                    //        return response;
                    //    }
                    //},
                    new Route()
                    {
                        Name = "Controller/Action/GET",
                        Method = RequestMethod.GET,
                        UrlRegex = @"^/(.+)/(.+)$",
                        Callable = new ControllerRouter().Handle
                    },
                    new Route()
                    {
                        Name = "Controller/Action/POST",
                        Method = RequestMethod.POST,
                        UrlRegex = @"^/(.+)/(.+)$",
                        Callable = new ControllerRouter().Handle
                    }
                };
            }
        }
    }
}
