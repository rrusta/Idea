using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Idea.Domain.Models
{
    public class UserTypes
    {
        [Key]
        public int UserTypeId { get; set; }

        public string Description { get; set; }
    }
}
