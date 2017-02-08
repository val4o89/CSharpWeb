using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace SimpleHttpServer.Models
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
            throw new NotImplementedException();
        }

        private HttpRequest GetRequest(NetworkStream stream)
        {
            string[] firstRequestLine = StreamUtils.ReadLine(stream).Split(' ');

            if (firstRequestLine.Length < 3)
            {
                throw new Exception();
            }

            Header header = new Header(Enums.HeaderType.HttpRequest);
            string line;

            while ((line = StreamUtils.ReadLine(stream)) != null)
            {
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
            }
            return null;

        }
    }
}
