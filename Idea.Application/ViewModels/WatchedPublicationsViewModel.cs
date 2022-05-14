using System;
using System.Collections.Generic;
using System.Text;

namespace Idea.Application.ViewModels
{
    public class WatchedPublicationsViewModel
    {
        public WatchedPublicationsViewModel() 
        {
            CreatedAt = DateTime.Now;
        }

        public int? PublicationId { get; set; }
        public string UserId { get; set; }
        public DateTime? CreatedAt { get; set; }

    }
}