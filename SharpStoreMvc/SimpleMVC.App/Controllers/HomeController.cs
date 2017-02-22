using SimpleHttpServer.Models;
using SimpleMVC.App.BindingModels;
using SimpleMVC.App.Data;
using SimpleMVC.App.Models;
using SimpleMVC.App.MVC.Attributes.Methods;
using SimpleMVC.App.MVC.Controllers;
using SimpleMVC.App.MVC.Interfaces;
using SimpleMVC.App.MVC.Interfaces.Generic;
using SimpleMVC.App.ViewModels;
using SimpleMVC.App.Views.Home;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace SimpleMVC.App.Controllers
{
    public class HomeController : Controller
    {
        private KnivesDbContext db;
        public HomeController()
        {
            this.db = new KnivesDbContext();
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult About()
        {
            return View();
        }

        [HttpGet]
        public IActionResult<IEnumerable<ProductsViewModel>> Products(string name)
        {
            IEnumerable<ProductsViewModel> viewModels;

            if (name != null)
            {
                viewModels = new List<ProductsViewModel>(db.Knives.Where(x => x.Name.Contains(name)).Select(x => new ProductsViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Prie,
                    Url = x.Url
                }));
            }
            else
            {
                viewModels = new List<ProductsViewModel>(db.Knives.Select(x => new ProductsViewModel
                {
                    Id = x.Id,
                    Name = x.Name,
                    Price = x.Prie,
                    Url = x.Url
                }));
            }

            return View(viewModels);
        }
        [HttpGet]
        public IActionResult Contacts()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Contacts(MessageBindingModel model)
        {
            var message = new Message
            {
                Email = model.Email,
                Subject = model.Subject,
                MessageText = model.MessageText
            };

            db.Messages.Add(message);

            db.SaveChanges();

            return View();
        }

        [HttpGet]
        public IActionResult<ProductsViewModel> Buy(int id)
        {
            var knife = db.Knives.FirstOrDefault(x => x.Id == id);

            ProductsViewModel viewModel = new ProductsViewModel
            {
                Id = knife.Id,
                Name = knife.Name,
                Price = knife.Prie,
                Url = knife.Url
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Buy(BoughtProductBindingModel model, HttpResponse response)
        {

            var boughtProduct = new BoughtKnives
            {
                BuyersName = model.BuyersName,
                DeliveryAddress = model.Address,
                Knife = db.Knives.FirstOrDefault(x => x.Id == model.KnifeId),
                PhoneNumber = model.PhoneNumber
            };

            db.BoughtKnives.Add(boughtProduct);

            db.SaveChanges();

            Redirect(response, "/home/products");

            return null;
        }

        [HttpGet]
        public IActionResult Dark(HttpResponse response)
        {
            File.WriteAllText("../../content/css/theme.css", ".navbar{background-color: black;}");

            Redirect(response, "/home/index/");

            return null;
        }

        [HttpGet]
        public IActionResult Light(HttpResponse response)
        {
            File.WriteAllText("../../content/css/theme.css", ".navbar{background-color: lightgrey;}");

            Redirect(response, "/home/index/");

            return null;
        }
    }
}
