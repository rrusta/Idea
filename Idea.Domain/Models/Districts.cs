using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Idea.Domain.Models
{
    public class Districts
    {
        //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int DistrictId { get; set; }

        public string Name { get; set; }

        public string DistrictCode { get; set; }

        public List<Towns> Towns { get; set; }
    }
}
