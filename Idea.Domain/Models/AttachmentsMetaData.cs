using System;
using System.Collections.Generic;
using System.Text;

namespace Idea.Domain.Models
{
    public class AttachmentsMetaData
    {
        public int AttachmentsMetaDataId { get; set; }

        public string ReferenceId { get; set; }

        public string AttachmentUrl { get; set; }

        public int AttachmentTypeId { get; set; }
        public AttachmentTypes AttachmentType { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string AttachmentFormat { get; set; }

        public string Extension { get; set; }

        public decimal? AttachmentSize { get; set; }

        public DateTime CreatedAt { get; set; }

        public bool? IsSelected { get; set; }
    }
}
