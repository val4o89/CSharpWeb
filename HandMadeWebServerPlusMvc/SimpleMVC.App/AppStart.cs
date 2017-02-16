using SimpleHttpServer;
using SimpleMVC.App.MVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleMVC.App
{
    public class AppStart
    {
        static void Main(string[] args)
        {
            HttpServer server = new HttpServer(80, RouteTable.Routes);
            MvcEngine.Run(server);
        }
    }
}
