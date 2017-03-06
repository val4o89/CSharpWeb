namespace Store.App.Controllers
{
    using BindingModels;
    using Services;
    using SimpleHttpServer.Models;
    using SimpleMVC.Attributes.Methods;
    using SimpleMVC.Controllers;
    using SimpleMVC.Interfaces;
    using SimpleMVC.Interfaces.Generic;
    using System;
    using System.Collections.Generic;
    using ViewModels;

    public class ManagerController : Controller
    {
        private GameManagerService service;
        private AutenticationService autenticator;

        public ManagerController()
        {
            this.service = new GameManagerService();
            this.autenticator = new AutenticationService();
        }

        [HttpGet]
        public IActionResult<IEnumerable<ManageGameViewModel>> All(HttpSession session, HttpResponse response)
        {
            if (autenticator.HasLoggedInUser(session))
            {
                if (autenticator.IsLoggedUserAdmin(session))
                {
                    var games = service.GetAllGames();
                    return View(games);
                }
            }

            this.Redirect(response, "/home/login");
            return null;
        }

        [HttpGet]
        public IActionResult<DeleteGameViewModel> Delete(int id, HttpSession session, HttpResponse response)
        {
            if (autenticator.HasLoggedInUser(session))
            {
                if (autenticator.IsLoggedUserAdmin(session))
                {
                    var viewModel = this.service.GetDeletableGameData(id);
                    return View(viewModel);
                }
            }

            this.Redirect(response, "/home/login");
            return null;
        }

        [HttpPost]
        public IActionResult Delete(DeleteGameBindingModel model, HttpSession session, HttpResponse response)
        {
            if (autenticator.HasLoggedInUser(session))
            {
                if (autenticator.IsLoggedUserAdmin(session))
                {
                    this.service.DeleteGame(model);

                    this.Redirect(response, "/manager/all");

                    return null;
                }
            }

            this.Redirect(response, "/users/login");
            return null;
        }

        [HttpGet]
        public IActionResult<GameViewModel> Edit(int id, HttpSession session, HttpResponse response)
        {
            if (autenticator.HasLoggedInUser(session))
            {
                if (autenticator.IsLoggedUserAdmin(session))
                {
                    var viewModel = this.service.GetEditableModel(id);

                    return View(viewModel);
                }
            }
            this.Redirect(response, "/users/login");

            return null;
        }

        [HttpPost]
        public IActionResult Edit(EditUserBindingModel model, HttpResponse response, HttpSession session)
        {
            if (autenticator.HasLoggedInUser(session))
            {
                if (autenticator.IsLoggedUserAdmin(session))
                {
                    if (service.AreValidGameChanges(model))
                    {
                        this.service.EditGame(model);

                        this.Redirect(response, "/manager/all");
                        return null;
                    }
                }
            }

            this.Redirect(response, "/users/login");

            return null;
        }
    }
}
