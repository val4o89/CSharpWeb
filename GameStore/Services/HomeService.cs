namespace Services
{
    using SimpleHttpServer.Models;
    using Store.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using UnitOfWork.UoW;

    public class HomeService
    {
        private UnitOfWork uow;

        //thumbnail, title, price, size, description) 
        public HomeService()
        {
            this.uow = new UnitOfWork();
        }

        public IEnumerable<GameViewModel> GetAllGameViewModels()
        {
            return this.uow.Games.Select(g => new GameViewModel
            {
                Thumbnail = g.ImageThumbnail,
                Description = g.Description,
                Price = g.Price,
                Title = g.Title,
                Size = g.Size,
                YoutubeId = g.Trailer,
                ReleaseDate = g.ReleaseDate,
                GameId = g.Id
            });
        }

        public IEnumerable<GameViewModel> GetOwnedGameViewModels(HttpSession session)
        {
            var login = this.uow.Logins.FindFirst(l => l.SessionId == session.Id && l.IsActive == true);

            var games = this.uow.Users.FindFirst(u => u.Id == login.UserId).Games;

            return games.Select(g => new GameViewModel
            {
                Thumbnail = g.ImageThumbnail,
                Description = g.Description,
                Price = g.Price,
                Title = g.Title,
                Size = g.Size,
                YoutubeId = g.Trailer,
                ReleaseDate = g.ReleaseDate,
                GameId = g.Id
            });
        }

        public GameViewModel GetGameById(int id)
        {
            var game = this.uow.Games.FindFirst(g => g.Id == id);
            return new GameViewModel
            {
                Description = game.Description,
                GameId = game.Id,
                Price = game.Price,
                ReleaseDate = game.ReleaseDate,
                Size = game.Size,
                Thumbnail = game.ImageThumbnail,
                Title = game.Title,
                YoutubeId = game.Trailer
            };
        }

        public int GetLoggedUsersId(HttpSession session)
        {
            return this.uow.Logins.FindFirst(l => l.SessionId == session.Id && l.IsActive == true).UserId;
        }

        public void BuyGame(int userId, int gameId)
        {
            if (!this.uow.Users.FindFirst(u => u.Id == userId).Games.Any(g => g.Id == gameId))
            {
                this.uow.Users.FindFirst(u => u.Id == userId).Games.Add(this.uow.Games.FindFirst(g => g.Id == gameId));
                this.uow.SaveChanges();
            }
        }
    }
}
