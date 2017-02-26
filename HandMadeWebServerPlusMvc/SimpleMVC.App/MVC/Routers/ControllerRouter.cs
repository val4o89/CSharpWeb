namespace SimpleMVC.App.MVC.Routers
{
    using SimpleMVC.App.MVC.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SimpleHttpServer.Models;
    using SimpleHttpServer.Enums;
    using System.Net;
    using System.Globalization;
    using System.Reflection;
    using SimpleMVC.App.MVC.Attributes.Methods;
    using SimpleMVC.App.MVC.Controllers;
    public class ControllerRouter : IHandleable
    {
        private IDictionary<string, string> getParams;
        private IDictionary<string, string> postParams;
        private string requestMethod;
        private string controllerName;
        private string actionName;
        private object[] methodParams;

        public ControllerRouter()
        {
            this.getParams = new Dictionary<string, string>();
            this.postParams = new Dictionary<string, string>();
        }

        private MethodInfo GetMethod()
        {
            MethodInfo method = null;

            foreach (MethodInfo methodInfo in GetSuitableMethods())
            {
                IEnumerable<Attribute> attributes = methodInfo.GetCustomAttributes().Where(a => a is HttpMethodAttribute);

                if (!attributes.Any())
                {
                    return methodInfo;
                }

                foreach (HttpMethodAttribute attribute in attributes)
                {
                    if (attribute.IsValid(requestMethod))
                    {
                        return methodInfo;
                    }
                }
            }

            return method;
        }

        private IEnumerable<MethodInfo> GetSuitableMethods()
        {
            return this.GetController().GetType().GetMethods().Where(x => x.Name == this.actionName);
        }

        private Controller GetController()
        {
            var controllerType = string.Format("{0}.{1}.{2}", MvcContext.Current.AssemblyName, MvcContext.Current.ControllersFolder, this.controllerName);

            var controller = (Controller)Activator.CreateInstance(Type.GetType(controllerType));

            return controller;
        }

        public HttpResponse Handle(HttpRequest request)
        {
            this.RetrieveRequestParams(request);

            this.requestMethod = request.Method.ToString();

            string[] urlComponents = request.Url.Split('/');

            if (urlComponents.Length >= 2)
            {
                this.controllerName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(urlComponents[1]) + "Controller";

                this.actionName = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(urlComponents[2].Split('?')[0]);
            }

            MethodInfo method = GetMethod();

            if (method == null)
            {
                throw new NotSupportedException("No such method!");
            }

            //////////////////////////////////////////

            IEnumerable<ParameterInfo> parameters = method.GetParameters();

            this.methodParams = new object[parameters.Count()];

            int index = 0;

            foreach (ParameterInfo param in parameters)
            {
                if (param.ParameterType.IsPrimitive)
                {
                    object value = this.getParams[param.Name];

                    this.methodParams[index] = Convert.ChangeType(value, param.ParameterType);
                    index++;

                }
                else
                {
                    Type bindingModelType = param.ParameterType;
                    object bindingModel = Activator.CreateInstance(bindingModelType);

                    IEnumerable<PropertyInfo> properties = bindingModelType.GetProperties();

                    foreach (PropertyInfo property in properties)
                    {
                        property.SetValue(bindingModel, Convert.ChangeType(postParams[property.Name], property.PropertyType));

                    }
                    this.methodParams[index] = Convert.ChangeType(bindingModel, bindingModelType);
                    index++;

                }
            }

            IInvocable actionResult = (IInvocable)this.GetMethod().Invoke(this.GetController(), this.methodParams);

            string content = actionResult.Invoke();

            var response = new HttpResponse
            {
                StatusCode = ResponseStatusCode.Ok,
                ContentAsUTF8 = content
            };

            return response;

            //////////////////////////////////////////

        }

        private void RetrieveRequestParams(HttpRequest request)
        {
            if (request.Method == RequestMethod.GET)
            {
                string @params = WebUtility.UrlDecode(request.Url.Substring(request.Url.IndexOf('?') + 1));

                string[] paramsArr = @params.Split('&');

                foreach (var param in paramsArr)
                {
                    var kvp = param.Split('=').Select(x => x.Trim()).ToArray();

                    if (kvp.Length == 2)
                    {
                        getParams[kvp[0]] = kvp[1];
                    }
                }
            }
            else if (request.Method == RequestMethod.POST)
            {
                string @params = WebUtility.UrlDecode(request.Content);

                string[] paramsArr = @params.Split('&');

                foreach (var param in paramsArr)
                {
                    var kvp = param.Split('=').Select(x => x.Trim()).ToArray();

                    if (kvp.Length == 2)
                    {
                        postParams[kvp[0]] = kvp[1];
                    }
                }
            }
        }

        
    }
}
