using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Idea.Domain.Models
{
    public class PublicationStates
    {
        [Key]
        public int PublicationStateId { get; set; }

        public string Description { get; set; }
    }
}
