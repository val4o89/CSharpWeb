namespace SimpleMVC.App.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Knife
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Prie { get; set; }

        public string Url { get; set; }
    }
}
