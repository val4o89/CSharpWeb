namespace SimpleMVC.App.MVC.Controllers
{
    using SimpleMVC.App.MVC.Interfaces;
    using SimpleMVC.App.MVC.Interfaces.Generic;
    using SimpleMVC.App.MVC.ViewEngine;
    using SimpleMVC.App.MVC.ViewEngine.Generic;
    using System.Runtime.CompilerServices;
    public abstract class Controller
    {
        protected IActionResult View([CallerMemberName] string callee = "")
        {
            string controllerName = this.GetType().Name.Replace(MvcContext.Current.ControlersSuffix, string.Empty);

            string fullQualifiedName = string.Format("{0}.{1}.{2}.{3}",
                MvcContext.Current.AssemblyName,
                MvcContext.Current.ViewsFolder,
                controllerName,
                callee);

            return new ActionResult(fullQualifiedName);
        }

        protected IActionResult View(string controller, string action)
        {
            string fullQualifiedName = string.Format("{0}.{1}.{2}.{3}",
                MvcContext.Current.AssemblyName,
                MvcContext.Current.ViewsFolder,
                controller,
                action);

            return new ActionResult(fullQualifiedName);
        }

        protected IActionResult<T> View<T>(T model, [CallerMemberName] string callee = "")
        {
            string controllerName = this.GetType().Name.Replace(MvcContext.Current.ControlersSuffix, string.Empty);

            string fullQualifiedName = string.Format("{0}.{1}.{2}.{3}",
                MvcContext.Current.AssemblyName,
                MvcContext.Current.ViewsFolder,
                controllerName,
                callee);

            return new ActionResult<T>(fullQualifiedName, model);
        }

        protected IActionResult<T> View<T>( T model, string controller, string action)
        {
            string fullQualifiedName = string.Format("{0}.{1}.{2}.{3}",
                MvcContext.Current.AssemblyName,
                MvcContext.Current.ViewsFolder,
                controller,
                action);

            return new ActionResult<T>(fullQualifiedName, model);
        }
    }
}
