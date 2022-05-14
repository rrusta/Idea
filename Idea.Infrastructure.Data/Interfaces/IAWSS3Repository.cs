using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Idea.Infrastructure.Data.Interfaces
{
    public interface IAWSS3Repository
    {
        Task<string> UploadImage(IFormFile file);
    }
}
