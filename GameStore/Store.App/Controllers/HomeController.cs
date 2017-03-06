namespace Store.App.Controllers
{
    using Services;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;
    using ViewModels;
    using System;
    using System.Collections.Generic;
    using SimpleHttpServer.Models;
    using BindingModels;

    public class HomeController : Controller
    {
        private AutenticationService autenticator;
        private HomeService service;

        public HomeController()
        {
            autenticator = new AutenticationService();
            this.service = new HomeService();
        }

        [HttpGet]
        public IActionResult<IEnumerable<GameViewModel>> All(HttpResponse response, HttpSession sesion)
        {
            if (autenticator.HasLoggedInUser(sesion))
            {
                var allGamesViewModel = this.service.GetAllGameViewModels();
                return this.View(allGamesViewModel);
            }
            else
            {
                this.Redirect(response, "/users/login");
                return null;
            }

        }

        [HttpGet]
        public IActionResult<IEnumerable<GameViewModel>> Owned(HttpResponse response, HttpSession session)
        {
            if (autenticator.HasLoggedInUser(session))
            {
                var ownedGamesViewModel = this.service.GetOwnedGameViewModels(session);
                return this.View(ownedGamesViewModel);
            }
            else
            {
                this.Redirect(response, "/users/login");
                return null;
            }
        }

        [HttpGet]
        public IActionResult<GameViewModel> Details(int id)
        {
            var game = service.GetGameById(id);

            return View(game);
        }

        [HttpPost]
        public IActionResult Buy(BuyGameBindingModel model, HttpSession session, HttpResponse response)
        {
            if (this.autenticator.HasLoggedInUser(session))
            {
                var userId = this.service.GetLoggedUsersId(session);
                this.service.BuyGame(userId, model.Id);

                this.Redirect(response, "/home/all");
                return null;
            }
            else
            {
                this.Redirect(response, "/users/login");

                return null;
            }
        }
    }
}
