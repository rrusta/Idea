using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Idea.Domain.Models
{
    public class FavoritePublications
    {
        [Key]
        public int FavoritePublicationId { get; set; }

        public string UserId { get; set; }

        public int PublicationId { get; set; }
        public Publications Publication { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
