﻿using SimpleHttpServer.Enums;
using SimpleHttpServer.Models;
using SimpleHttpServer.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;

namespace SimpleHttpServer.Core
{
    public class HttpProcessor
    {
        private IList<Route> Routes;
        private HttpRequest Request;
        private HttpResponse Response;

        public HttpProcessor(IEnumerable<Route> routes)
        {
            this.Routes = new List<Route>(routes);
        }

        public void HandleClient(TcpClient tcpClient)
        {
            using (var stream = tcpClient.GetStream())
            {
                Request = GetRequest(stream);
                Response = RouteRequest();
                StreamUtils.WriteResponse(stream, Response);
            }
        }

        private HttpResponse RouteRequest()
        {
            var routes = this.Routes
    .Where(x => Regex.Match(Request.Url, x.UrlRegex).Success)
    .ToList();

            if (!routes.Any())
                return HttpResponseBuilder.NotFound();

            var route = routes.FirstOrDefault(x => x.Method == Request.Method);

            if (route == null)
                return new HttpResponse()
                {
                    StatusCode = ResponseStatusCode.MethodNotAllowed
                };

            #region FIleSystemHandler
            // extract the path if there is one
            //var match = Regex.Match(request.Url, route.UrlRegex);
            //if (match.Groups.Count > 1)
            //{
            //    request.Path = match.Groups[1].Value;
            //}
            //else
            //{
            //    request.Path = request.Url;
            //}
            #endregion


            // trigger the route handler...
            try
            {
                return route.Callable(Request);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                return HttpResponseBuilder.InternalServerError();
            }
        }

        private HttpRequest GetRequest(NetworkStream stream)
        {
            string[] firstRequestLine = StreamUtils.ReadLine(stream).Split(' ').Select(x => x.Trim()).ToArray();

            if (firstRequestLine.Length < 3)
            {
                throw new Exception();
            }

            RequestMethod method = (RequestMethod)Enum.Parse(typeof(RequestMethod), firstRequestLine[0]);
            string url = firstRequestLine[1];
            string protocolVersion = firstRequestLine[2];

            Header header = new Header(Enums.HeaderType.HttpRequest);
            string line;

            while ((line = StreamUtils.ReadLine(stream)) != null)
            {
                if (line == "")
                {
                    break;
                }

                string[] headerLine = line.Split(':');

                if (headerLine[0] == "Cookie")
                {
                    var cookies = headerLine[1].Split(';');

                    foreach (var cookie in cookies)
                    {
                        var cookieData = cookie.Split('=');
                        var cookieEntity = new Cookie(cookieData[0], cookieData[1]);
                        header.Cookies.AddCookie(cookieEntity);
                    }
                }
                else if (headerLine[0] == "Content-Length")
                {
                    header.ContentLength = headerLine[1];
                }
                else
                {
                    header.OtherParameters.Add(headerLine[0], headerLine[1]);
                }
            }
            string content = null;

            if (header.ContentLength != null)
            {
                int totalBytes = int.Parse(header.ContentLength);
                int bytesLeft = totalBytes;
                byte[] bytes = new byte[totalBytes];

                while (bytesLeft > 0)
                {
                    byte[] buffer = new byte[bytesLeft > 1024 ? 1024 : bytesLeft];
                    int n = stream.Read(buffer, 0, buffer.Length);
                    buffer.CopyTo(bytes, totalBytes - bytesLeft);
                    bytesLeft -= n;
                }

                content = Encoding.ASCII.GetString(bytes);
            }

            var request = new HttpRequest()
            {
                Method = method,
                Url = url,
                Content = content,
                Header = header
            };

            Console.WriteLine("-REQUEST-----------------------------");
            Console.WriteLine(request);
            Console.WriteLine("------------------------------");

            return request;

        }
    }
}
