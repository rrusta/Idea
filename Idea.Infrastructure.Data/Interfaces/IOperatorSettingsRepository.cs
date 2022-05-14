using Idea.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Idea.Infrastructure.Data.Interfaces
{
    public interface IOperatorSettingsRepository
    {
        OperatorSettings GetOperatorSettings(string description);
        Task<OperatorSettings> GetOperatorSettingsAsync(string description);
    }
}
