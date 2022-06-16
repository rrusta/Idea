using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Idea.Domain.Models
{
    public class PublicationMainCategories
    {
        [Key]
        public int PublicationMainCategoryId { get; set; }

        public string Description { get; set; }
    }
}
