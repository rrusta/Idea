using System;
using System.Collections.Generic;
using System.Text;

namespace Idea.Domain.DTOs.InsertDTOs
{
    public class UserMessageEmail
    {
        public string FromEmail { get; set; }
        public string ToEmail { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; }
        public int PublicationId { get; set; }
    }
}
