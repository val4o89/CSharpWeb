namespace Store.ViewModels
{
    using System;

    public class GameViewModel
    {
        //thumbnail, title, price, size, description) 

        public int GameId{get;set;}
         public string YoutubeId { get; set; }
        public string Thumbnail { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public decimal Size { get; set; }
        public string Description { get; set; }

        public DateTime? ReleaseDate { get; set; }
    }
}
