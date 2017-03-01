using Data;
using Models;
using PizzaMore.BindingModels;
using PizzaMore.Services;
using SimpleHttpServer.Models;
using SimpleMVC.Attributes.Methods;
using SimpleMVC.Controllers;
using SimpleMVC.Interfaces;
using SimpleMVC.Interfaces.Generic;
using System.Collections.Generic;
using System.Linq;

namespace PizzaMore.Controllers
{
    public class HomeController : Controller
    {
        private PizzaDbContext db;

        public HomeController()
        {
            db = new PizzaDbContext();
        }

        [HttpGet]
        public IActionResult Index(HttpRequest request, HttpResponse response)
        {
            if (request.Header.Cookies.Contains("lang") && request.Header.Cookies["lang"].Value != "EN")
            {
                Redirect(response, "/home/indexde");

                return null;
            }
            return View();
        }

        [HttpGet]
        public IActionResult Indexde(HttpRequest request, HttpResponse response)
        {
            if (request.Header.Cookies.Contains("lang") && request.Header.Cookies["lang"].Value != "DE")
            {
                Redirect(response, "/home/index");
                return null;
            }
            return View();
        }

        [HttpGet]
        public IActionResult Language(HttpResponse response, string language)
        {

            LangService.SetLanguage(response, language);

            if (response.Header.Cookies["lang"].Value == "EN")
            {
                Redirect(response, "/home/index");
            }
            else
            {
                Redirect(response, "/home/indexde");
            }

            return null;
        }

        [HttpGet]
        public IActionResult Signup()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signup(HttpResponse response, UserBindingModel model)
        {
            UserService.Register(this.db, model);

            Redirect(response, "/home/index");

            return null;
        }

        [HttpGet]
        public IActionResult Signin()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Signin(HttpResponse response, HttpSession session, UserBindingModel model)
        {
            UserService.SignIn(this.db, session, model);

            if (UserService.HasLoggedInUser(session, this.db))
            {
                Redirect(response, "/home/index");
            }
            else
            {
                Redirect(response, "/home/signup");
            }

            return null;
        }

        [HttpGet]
        public IActionResult<ICollection<Pizza>> Menu(HttpResponse response, HttpRequest request, HttpSession session)
        {
            if (UserService.HasLoggedInUser(session, this.db))
            {
                ICollection<Pizza> pizzas = this.db.Pizzas.ToList();
                return View(pizzas);
            }
            else
            {
                Redirect(response, "/home/index");
            }
            return null;
        }

        [HttpPost]
        public IActionResult Menu(VoteBindingModel model, HttpSession session, HttpResponse response)
        {
            if (UserService.HasLoggedInUser(session, this.db))
            {
                if (model.Vote == 1)
                {
                    db.Pizzas.FirstOrDefault(p => p.Id == model.PizzaId).UpVotes += 1;
                }
                else
                {
                    db.Pizzas.FirstOrDefault(p => p.Id == model.PizzaId).DownVotes -= 1;
                }

                db.SaveChanges();

                Redirect(response, "/home/menu");
            }

            return null;
        }

        [HttpGet]
        public IActionResult Signout(HttpSession session, HttpResponse response)
        {
            UserService.SignOut(session, this.db);

            Redirect(response, "/home/index");

            return null;
        }

        [HttpGet]
        public IActionResult<ICollection<Pizza>> Mysuggestions(HttpSession session)
        {
            var login = db.Logins.FirstOrDefault(l => l.SessionId == session.Id && l.IsActive == true);

            ICollection<Pizza> pizzas = this.db.Pizzas.Where(p => p.OwnerId == login.UserId).ToList();

            return View(pizzas);
        }

        [HttpGet]
        public IActionResult<int> Addsuggestion(HttpSession sesion)
        {
            var userId = this.db.Logins.FirstOrDefault(l => l.SessionId == sesion.Id).UserId;
            return View(userId);
        }

        [HttpPost]
        public IActionResult Addsuggestion(PizzaBindingModel model, HttpResponse response)
        {
            this.db.Pizzas.Add(new Pizza
            {
                OwnerId = model.OwnerId,
                ImageUrl = model.ImageUrl,
                Reciepe = model.Reciepe,
                Title = model.Title,
                DownVotes = 0,
                UpVotes = 0

            });

            db.SaveChanges();

            Redirect(response, "/home/mysuggestions");

            return null;
        }
    }
}
