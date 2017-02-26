namespace SimpleMVC.App.MVC
{
    using SimpleHttpServer;
    using System;
    using System.Reflection;

    public static class MvcEngine
    {
        public static void Run(HttpServer server)
        {
            RegisterAssemblyName();
            RegisterControllers();
            RegisterViews();
            RegisterModels();

            try
            {
                server.Listen();
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
            
        }

        private static void RegisterViews()
        {
            MvcContext.Current.ViewsFolder = "Views";
        }

        private static void RegisterModels()
        {
            MvcContext.Current.ModelsFolder = "Models";
        }

        private static void RegisterControllers()
        {
            MvcContext.Current.ControllersFolder = "Controllers";
            MvcContext.Current.ControlersSuffix = "Controller";
        }

        private static void RegisterAssemblyName()
        {
            MvcContext.Current.AssemblyName = Assembly.GetExecutingAssembly().GetName().Name;
        }
    }
}
