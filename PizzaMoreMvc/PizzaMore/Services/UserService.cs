using Data;
using Models;
using PizzaMore.BindingModels;
using SimpleHttpServer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaMore.Services
{
    public static class UserService
    {
        public static void Register(PizzaDbContext db, UserBindingModel model)
        {
            var user = new User
            {
                Email = model.Email,
                Password = model.Password
            };

            db.Users.Add(user);
            db.SaveChanges();
        }

        public static void SignIn(PizzaDbContext db, HttpSession session, UserBindingModel model)
        {
            if (!db.Users.Any(u => u.Email == model.Email && u.Password == model.Password))
            {
                return;
            }

            var login = new LogIn
            {
                SessionId = session.Id,
                IsActive = true,
                User = db.Users.FirstOrDefault(u => u.Email == model.Email && u.Password == model.Password)
            };

            db.Logins.Add(login);
            db.SaveChanges();

        }

        public static void SignOut(HttpSession session, PizzaDbContext db)
        {
            if (HasLoggedInUser(session, db))
            {

                foreach (var login in db.Logins.Where(l => l.SessionId == session.Id))
                {
                    login.IsActive = false;
                }

                db.SaveChanges();
            }
        }

        public static bool HasLoggedInUser(HttpSession session, PizzaDbContext db)
        {
            if (db.Logins.Any(l => l.SessionId == session.Id && l.IsActive == true))
            {
                return true;
            }

            return false;
        }
    }
}
