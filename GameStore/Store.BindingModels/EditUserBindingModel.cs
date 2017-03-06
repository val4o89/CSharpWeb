namespace Store.BindingModels
{
    using System;

    public class EditUserBindingModel
    {
        public int Id { get; set; }
        public string YoutubeId { get; set; }
        public string Thumbnail { get; set; }

        public string Title { get; set; }

        public decimal Price { get; set; }

        public decimal Size { get; set; }
        public string Description { get; set; }

    }
}
