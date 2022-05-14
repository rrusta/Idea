using System;
using System.Collections.Generic;
using System.Text;

namespace Idea.Application.ViewModels
{
    public class ApprovePublicationViewModel
    {
        public int PublicationId { get; set; }

        public int PublicationStatusId { get; set; }

        public List<int> RejectReasons { get; set; } 
    }
}
