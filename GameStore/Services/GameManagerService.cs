namespace Services
{
    using Store.ViewModels;
    using System;
    using System.Collections.Generic;
    using UnitOfWork.UoW;
    using Store.BindingModels;

    public class GameManagerService
    {
        private UnitOfWork uow;

        public GameManagerService()
        {
            this.uow = new UnitOfWork();
        }

        public IEnumerable<ManageGameViewModel> GetAllGames()
        {
            return this.uow.Games.Select(g => new ManageGameViewModel
            {
                Id = g.Id,
                Name = g.Title,
                Price = g.Price,
                Size = g.Size
            });
        }

        public DeleteGameViewModel GetDeletableGameData(int id)
        {
            var game = this.uow.Games.FindFirst(g => g.Id == id);

            return new DeleteGameViewModel
            {
                Name = game.Title,
                Id = game.Id
            };
        }

        public void DeleteGame(DeleteGameBindingModel model)
        {
            this.uow.Games.Delete(g => g.Id == model.Id);

            this.uow.SaveChanges();
        }

        public GameViewModel GetEditableModel(int id)
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

        public void EditGame(EditUserBindingModel model)
        {
            Game game = this.uow.Games.FindFirst(g => g.Id == model.Id);
            game.Description = model.Description;
            game.ImageThumbnail = model.Thumbnail;
            game.Price = model.Price;
            game.Size = model.Size;
            game.Title = model.Title;
            game.Trailer = model.YoutubeId;

            this.uow.SaveChanges();
        }

        public bool AreValidGameChanges(EditUserBindingModel model)
        {
            if (!char.IsUpper(model.Title[0]) || model.Title.Length < 3 || model.Title.Length > 100)
            {
                return false;
            }

            if (model.Price < 0.0m)
            {
                return false;
            }

            if (model.Size < 0.0m)
            {
                return false;
            }

            if (model.YoutubeId.Length != 11)
            {
                return false;
            }

            if (model.Description.Length < 20)
            {
                return false;
            }

            return true;
        }
    }
}
