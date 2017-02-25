
namespace SimpleHttpServer.Core
{
    using Models;
    using System.Collections.Generic;
    using System.Net;
    using System.Net.Sockets;
    using System.Threading;

    public class HttpServer
    {
        public HttpServer(int port, IEnumerable<Route> routes)
        {
            this.Port = port;
            this.Processor = new HttpProcessor(routes);
            this.IsActive = true;
        }

        public TcpListener Listener { get; private set; }

        public int Port { get; set; }

        public HttpProcessor Processor { get; private set; }

        public bool IsActive { get; set; }

        public void Listen()
        {
            this.Listener = new TcpListener(IPAddress.Any, this.Port);

            this.Listener.Start();
            while (IsActive)
            {
                var client = this.Listener.AcceptTcpClient();

                var thread = new Thread(() =>
                {
                    Processor.HandleClient(client);
                });

                thread.Start();

                Thread.Sleep(1);
            }
        }
    }
}
