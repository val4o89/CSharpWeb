namespace Services
{
    using UnitOfWork.UoW;
    using Store.BindingModels;
    using System.Linq;
    using Store.ViewModels;
    using SimpleHttpServer.Models;
    using System;

    public class UserService
    {
        private UnitOfWork uow;

        public UserService()
        {
            this.uow = new UnitOfWork();
        }
        public bool IsValidUserToRegister(RegisterUserBindingModel model)
        {
            if (!model.Email.Contains(".") || !model.Email.Contains("@"))
            {
                return false;
            }

            if (uow.Users.Any(u => u.Email == model.Email))
            {
                return false;
            }

            if (!model.Password.Any(char.IsUpper) || !model.Password.Any(char.IsLower) || !model.Password.Any(char.IsDigit))
            {
                return false;
            }

            if (model.Password.Length < 6)
            {
                return false;
            }

            if (model.Password != model.ConfirmPassword)
            {
                return false;
            }

            if (string.IsNullOrEmpty(model.FullName))
            {
                return false;
            }

            return true;
        }

        public void LoginUser(HttpSession session, LoginUserBindingModel model)
        {
            var user = this.uow.Users.FindFirst(u => u.Email == model.Email && u.Password == model.Password);

            var login = new Login
            {
                IsActive = true,
                SessionId = session.Id,
                User = user
            };

            this.uow.Logins.Add(login);

            this.uow.SaveChanges();
        }

        public bool ContainsUser(LoginUserBindingModel model)
        {
            return this.uow.Users.Any(u => u.Email == model.Email && u.Password == model.Password);
        }

        public void RegisterUser(RegisterUserBindingModel model)
        {
            var user = new User
            {
                Email = model.Email,
                FullName = model.FullName,
                Password = model.Password
            };

            if (!this.uow.Users.Any())
            {
                user.IsAdmin = true;
            }

            this.uow.Users.Add(user);

            this.uow.SaveChanges();
        }

        public void Logout(HttpSession session)
        {
            this.uow.Logins.FindFirst(l => l.SessionId == session.Id && l.IsActive == true).IsActive = false;

            this.uow.SaveChanges();
        }
    }
}
