using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forward_Solutions_Test_BE.Domain.Entities;

namespace Forward_Solutions_Test_BE.Domain.Interfaces
{
    public interface ICalculationRepository
    {
        Task SaveAsync(Calculation calculation);
        Task<List<Calculation>> GetAllAsync();
    }
}