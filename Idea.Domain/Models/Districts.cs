using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Idea.Domain.Models
{
    public class Districts
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int DistrictId { get; set; }

        public string Name { get; set; }

        public string DistrictCode { get; set; }

        public List<Towns> Towns { get; set; }
    }
}
