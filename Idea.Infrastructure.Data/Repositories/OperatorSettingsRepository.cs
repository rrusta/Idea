using Microsoft.EntityFrameworkCore;
using Idea.Domain.Context;
using Idea.Domain.Models;
using Idea.Infrastructure.Data.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Idea.Infrastructure.Data.Repositories
{
    public class OperatorSettingsRepository : IOperatorSettingsRepository
    {
        private readonly IdeaDbContext _ctx;

        public OperatorSettingsRepository(IdeaDbContext ctx)
        {
            _ctx = ctx;
        }
        public OperatorSettings GetOperatorSettings(string description)
        {
            var operatorSettings = _ctx.OperatorSettings.Where(x => x.Description == description).FirstOrDefault();

            return operatorSettings;
        }
        public async Task<OperatorSettings> GetOperatorSettingsAsync(string description)
        {
            var operatorSettings =await  _ctx.OperatorSettings.Where(x => x.Description == description).FirstOrDefaultAsync();

            return operatorSettings;
        }
    }
}
