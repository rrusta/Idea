

using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Idea.Domain.Data
{
    public class IdeaDbContext : IdentityDbContext
    {
            public IdeaDbContext(DbContextOptions<IdeaDbContext> options)
            : base(options)
        {
        }
    }
}
