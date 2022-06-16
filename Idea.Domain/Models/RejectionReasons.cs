using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Idea.Domain.Models
{
    public class RejectionReasons
    {
        [Key]
        public int RejectionReasonId { get; set; }

        public string Description { get; set; }
    }
}
