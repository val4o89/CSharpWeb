namespace Store.App.Controllers
{
    using Services;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using BindingModels;
    using System;
    using SimpleHttpServer.Models;

    public class UsersController : Controller
    {
        private UserService service;
        private AutenticationService autenticator;

        public UsersController()
        {
            service = new UserService();
            autenticator = new AutenticationService();
        }

        [HttpGet]
        public IActionResult Register(HttpResponse response, HttpSession session)
        {
            if (autenticator.HasLoggedInUser(session))
            {
                this.Redirect(response, "/home/index");
                return null;
            }
            return this.View();
        }

        [HttpPost]
        public IActionResult Register(HttpResponse response, RegisterUserBindingModel model)
        {
            if (service.IsValidUserToRegister(model))
            {
                service.RegisterUser(model);

                this.Redirect(response, "/users/login");
            }
            else
            {
                this.Redirect(response, "/users/register");
            }

            return null;
        }

        [HttpGet]
        public IActionResult Login(HttpResponse response, HttpSession session)
        {
            if (autenticator.HasLoggedInUser(session))
            {
                this.Redirect(response, "/home/all");
                return null;
            }

            return this.View();
        }

        [HttpPost]
        public IActionResult Login(HttpResponse response, HttpSession session, LoginUserBindingModel model)
        {
            if (this.service.ContainsUser(model))
            {
                this.service.LoginUser(session, model);
                this.Redirect(response, "/home/all");
            }
            else
            {
                this.Redirect(response, "/users/login");
            }

            return null;
        }

        [HttpPost]
        public IActionResult Logout(HttpSession session, HttpResponse response)
        {
            this.service.Logout(session);

            this.Redirect(response, "/users/login");

            return null;
        }
    }
}
