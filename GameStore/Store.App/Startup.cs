namespace Store.App
{
    using SimpleHttpServer;
    using SimpleMVC;
    using Routes;

    public class Startup
    {
        public static void Main()
        {
            HttpServer server = new HttpServer(80, RouteTable.Routes);
            MvcEngine.Run(server, "Store.App");
        }
    }
}
