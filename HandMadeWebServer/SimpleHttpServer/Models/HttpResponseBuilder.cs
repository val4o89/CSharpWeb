namespace SimpleHttpServer.Models
{
    using SimpleHttpServer.Enums;
    using System.IO;
    public static class HttpResponseBuilder
    {
        public static HttpResponse InternalServerError()
        {
            return new HttpResponse
            {
                ContentAsUTF8 = File.ReadAllText("../../../SimpleHttpServer/Resourses/Pages/500.html"),
                Header = new Header(HeaderType.HttpResponse),
                StatusCode = ResponseStatusCode.InternalServerError
            };
        }

        public static HttpResponse NotFound()
        {
            return new HttpResponse
            {
                ContentAsUTF8 = File.ReadAllText("../../../SimpleHttpServer/Resourses/Pages/404.html"),
                Header = new Header(HeaderType.HttpResponse),
                StatusCode = ResponseStatusCode.InternalServerError
            };
        }

    }
}
