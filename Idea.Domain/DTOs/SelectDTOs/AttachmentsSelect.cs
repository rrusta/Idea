using System;
using System.Collections.Generic;
using System.Text;

namespace RealEstate.Domain.DTOs.SelectDTOs
{
    public class AttachmentsSelect
    {
        public int AttachmentId { get; set; }

        public string Name { get; set; }

        public string Url { get; set; }

        public string Extension { get; set; }

        public bool? IsSelected { get; set; }

        public bool? FromDB { get; set; }
    }
}
