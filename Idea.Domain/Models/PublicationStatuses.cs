using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Idea.Domain.Models
{
    public class PublicationStatuses
    {
        [Key]
        public int PublicationStatusId { get; set; }

        public string Description { get; set; }
    }
}
