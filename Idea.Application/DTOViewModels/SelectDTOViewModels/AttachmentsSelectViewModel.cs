using System;
using System.Collections.Generic;
using System.Text;

namespace Idea.Application.DTOViewModels.SelectDTOViewModels
{
    public class AttachmentsSelectViewModel
    {
        public int AttachmentId { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string Extension { get; set; }

        public bool? IsSelected { get; set; }

        public bool? FromDB { get; set; }
    }
}
