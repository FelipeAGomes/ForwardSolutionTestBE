using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forward_Solutions_Test_BE.Domain.Entities
{
    public class Calculation
    {
        public double FirstNumber  { get; set;}
        public double SecondNumber { get; set;}
        public double Total { get; set;}
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}