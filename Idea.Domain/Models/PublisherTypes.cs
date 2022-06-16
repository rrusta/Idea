using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Idea.Domain.Models
{
    public class PublisherTypes
    {
        [Key]
        public int PublisherTypeId { get; set; }

        public string Description { get; set; }
    }
}
