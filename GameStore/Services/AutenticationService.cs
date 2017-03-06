namespace Services
{
    using System;
    using SimpleHttpServer.Models;
    using UnitOfWork.UoW;

    public class AutenticationService
    {
        private UnitOfWork uow;

        public AutenticationService()
        {
            this.uow = new UnitOfWork();
        }

        public bool HasLoggedInUser(HttpSession session)
        {
            return this.uow.Logins.Any(l => l.SessionId == session.Id && l.IsActive == true);
        }

        public bool IsLoggedUserAdmin(HttpSession session)
        {
            return this.uow.Logins.FindFirst(l => l.SessionId == session.Id && l.IsActive == true).User.IsAdmin;
        }
    }
}
