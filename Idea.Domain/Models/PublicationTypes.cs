using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Idea.Domain.Models
{
    public class PublicationTypes
    {
        [Key]
        public int PublicationTypeId { get; set; }

        public string Description { get; set; }
    }
}
