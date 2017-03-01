using PizzaMore.Routes;
using SimpleHttpServer;
using SimpleMVC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMore
{
    public class Startup
    {
        public static void Main()
        {
            HttpServer server = new HttpServer(80, RouteTable.Routes);
            MvcEngine.Run(server, "PizzaMore");
        }
    }
}
