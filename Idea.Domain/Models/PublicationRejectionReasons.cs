using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Idea.Domain.Models
{
    public class PublicationRejectionReasons
    {
        [Key]
        public int PublicationRejectionReasonsId { get; set; }

        public int RejectionReasonId { get; set; }
        public RejectionReasons RejectionReason { get; set; }

        public int PublicationId { get; set; }
        public Publications Publication { get; set; }
    }
}
