using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Idea.Domain.Models
{
    public class AttachmentTypes
    {
        [Key]
        public int AttachmentTypeId { get; set; }

        public string Description { get; set; }
    }
}
