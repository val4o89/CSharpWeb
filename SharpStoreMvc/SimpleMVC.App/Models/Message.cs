namespace SimpleMVC.App.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Message
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Subject { get; set; }

        public string MessageText { get; set; }
    }
}
