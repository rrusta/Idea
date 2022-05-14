using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Idea.Domain.DTOs.UpdateDTOs
{
    public class UpdateProfilePicture
    {
        public IFormFile File { get; set; }
        public string Email { get; set; }
    }
}
