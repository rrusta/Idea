using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Idea.Domain.Models
{
    public class UnitTypes
    {
        [Key]
        public int UnitTypeId { get; set; }

        public string Description { get; set; }
    }
}
