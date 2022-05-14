using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Idea.Application.DTOViewModels.UpdateDTOViewModels
{
    public class UpdateProfilePictureViewModel
    {
        public IFormFile File { get; set; }
        public string Email { get; set; }
    }
}
