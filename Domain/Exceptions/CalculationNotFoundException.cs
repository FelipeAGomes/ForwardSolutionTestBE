using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forward_Solutions_Test_BE.Domain.Exceptions
{
    public class CalculationNotFoundException(string message) : Exception(message)
    {
    }
}