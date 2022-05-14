using System;
using System.Collections.Generic;
using System.Text;

namespace Idea.Domain.Models
{
    public class PublicationCategories
    {
        public int PublicationCategoryId { get; set; }

        public string Description { get; set; }

        public int PublicationMainCategoryId { get; set; }
        public PublicationMainCategories PublicationMainCategory { get; set; }

        public bool? HasQuadrature { get; set; }

        public bool? HasArea { get; set; }

        public bool? ShowFirst { get; set; }
    }
}
