using System;
using System.Collections.Generic;
using System.Text;

namespace Idea.Domain.BaseModels
{
    public abstract class BaseModel
    {
        public string CreatedBy { get; set; }

        public DateTime CreatedAt { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime? LastUpdatedAt { get; set; }
    }
}
