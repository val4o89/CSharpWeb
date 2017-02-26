namespace SimpleMVC.App.Controllers
{
    using SimpleMvc.Data;
    using SimpleMVC.App.BindingModels;
    using SimpleMVC.App.MVC.Attributes.Methods;
    using SimpleMVC.App.MVC.Controllers;
    using SimpleMVC.App.MVC.Interfaces;
    using SimpleMVC.App.MVC.Interfaces.Generic;
    using SimpleMVC.App.ViewModels;
    using SimpleMVC.Models;
    using System.Collections.Generic;
    using System.Linq;
    public class UserController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(RegisterUserBindingModel model)
        {
            var user = new User
            {
                Username = model.Username,
                Password = model.Password
            };

            using (var context = new MvcDbContext())
            {
                context.Users.Add(user);
                context.SaveChanges();
            }
            return View();
        }

        [HttpGet]
        public IActionResult<AllNeededUserDataViewModel> All()
        {
            List<UserBindingModel> users = null;

            using (var context = new MvcDbContext())
            {
                users = context.Users.Select(x => new UserBindingModel
                {
                    Username = x.Username,
                    Id = x.iD
                }).ToList();
            }

            var viewModel = new AllNeededUserDataViewModel()
            {
                Users = users
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult<UserPrifileViewModel> Profile(int id)
        {
            using (var context = new MvcDbContext())
            {
                var user = context.Users.FirstOrDefault(x => x.iD == id);

                var viewModel = new UserPrifileViewModel
                {
                    Id = user.iD,
                    Username = user.Username,
                    Notes = user.Notes.Select(x => new NoteViewModel
                    {
                        Title = x.Title,
                        Content = x.Content
                    })
                };

                return View(viewModel);
            }
        }

        [HttpPost]
        public IActionResult<UserPrifileViewModel> Profile(AddNoteBindingModel model)
        {
            using (var context = new MvcDbContext())
            {
                var user = context.Users.FirstOrDefault(x => x.iD == model.Id);

                var note = new Note
                {
                    Title = model.Title,
                    Content = model.Content
                };
                user.Notes.Add(note);
                context.SaveChanges();

                return Profile(model.Id);
            }
        }
    }
}
