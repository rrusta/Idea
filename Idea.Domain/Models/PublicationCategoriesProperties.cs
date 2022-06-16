using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Idea.Domain.Models
{
    public class PublicationCategoriesProperties
    {
        [Key]
        public int PublicationCategoriesPropertiesId { get; set; }

        public int PublicationCategoryId { get; set; }
        public PublicationCategories PublicationCategory { get; set; }

        public string HasProperty { get; set; }
    }
}
