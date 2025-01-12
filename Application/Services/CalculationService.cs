using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forward_Solutions_Test_BE.Domain.Entities;
using Forward_Solutions_Test_BE.Domain.Exceptions;
using Forward_Solutions_Test_BE.Domain.Interfaces;

namespace Forward_Solutions_Test_BE.Application.Services
{
    public class CalculationService(ICalculationRepository calculatorRepository)
    {
        private readonly ICalculationRepository _calculatorRepository = calculatorRepository;

        public async Task<Calculation> AddAndSaveAsync(double firstNumber, double secondNumber)
        {
            var total = firstNumber + secondNumber;

            var calculation = new Calculation
            {
                FirstNumber = firstNumber,
                SecondNumber = secondNumber,
                Total = Math.Round(total, 2),
            };

            await _calculatorRepository.SaveAsync(calculation);
            return calculation;
        }

        public async Task<List<Calculation>> GetCalculationsAsync()
        {
            var calculations = await _calculatorRepository.GetAllAsync();

            if (calculations.Count == 0)
            {
                throw new CalculationNotFoundException("No calculations found.");
            }
            return calculations;
        }
    }
}