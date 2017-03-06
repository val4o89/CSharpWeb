namespace UnitOfWork.UoW
{
    using Contracts;
    using Store.Data;
    using Repository;
    using System;
    using Store.ViewModels;

    public class UnitOfWork : IUnitOfWork
    {
        private GameStoreDbContext context;

        private IRepository<User> users;
        private IRepository<Login> logins;
        private IRepository<Game> games;

        public UnitOfWork()
        {
            this.context = new GameStoreDbContext();
        }

        public IRepository<User> Users
        {
            get { return this.users ?? (users = new Repository<User>(this.context)); }
            set { this.users = value; }
        }

        public IRepository<Login> Logins
        {
            get { return this.logins ?? (logins = new Repository<Login>(this.context)); }
            set { this.logins = value; }
        }

        public IRepository<Game> Games
        {
            get { return this.games ?? (games = new Repository<Game>(this.context)); }
            set { this.games = value; }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }
    }
}
