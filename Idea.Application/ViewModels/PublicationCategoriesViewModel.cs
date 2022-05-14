using System;
using System.Collections.Generic;
using System.Text;

namespace Idea.Application.ViewModels
{
    public class PublicationCategoriesViewModel
    {
        public int PublicationCategoryId { get; set; }

        public string Description { get; set; }

        public int PublicationMainCategoryId { get; set; }

        public bool? HasQuadrature { get; set; }

        public bool? HasArea { get; set; }
        public bool? ShowFirst { get; set; }
    }
}
