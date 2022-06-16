using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Idea.Domain.Models
{
    public class Units
    {
        [Key]
        public int UnitId { get; set; }

        public int UnitTypeId { get; set; }
        public UnitTypes UnitType { get; set; }

        public string Description { get; set; }

        public string Symbol { get; set; }
    }
}
