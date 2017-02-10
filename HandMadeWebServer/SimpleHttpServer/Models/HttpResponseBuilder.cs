﻿using SimpleHttpServer.Enums;
using System.IO;

namespace SimpleHttpServer.Models
{
    public static class HttpResponseBuilder
    {
        public static HttpResponse InternalServerError()
        {
            return new HttpResponse
            {
                ContentAsUTF8 = File.ReadAllText("../Resourses/Pages/500.html"),
                Header = new Header(HeaderType.HttpResponse),
                StatusCode = ResponseStatusCode.InternalServerError
            };
        }

        public static HttpResponse NotFound()
        {
            return new HttpResponse
            {
                ContentAsUTF8 = File.ReadAllText("../Resourses/Pages/404.html"),
                Header = new Header(HeaderType.HttpResponse),
                StatusCode = ResponseStatusCode.InternalServerError
            };
        }

    }
}
