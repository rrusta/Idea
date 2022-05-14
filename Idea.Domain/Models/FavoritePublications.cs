﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Idea.Domain.Models
{
    public class FavoritePublications
    {
        public int FavoritePublicationId { get; set; }

        public string UserId { get; set; }

        public int PublicationId { get; set; }
        public Publications Publication { get; set; }

        public DateTime CreatedAt { get; set; }
    }
}
