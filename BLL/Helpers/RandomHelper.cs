using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Helpers
{
    public class RandomHelper:IRandomHelper
    {
        public double GetRandomDouble(double min, double max)
        {
            var random = new Random();
            return random.NextDouble() * (max - min) + min;
        }

        public bool IsSuccess(double probability)
        {
            var result = false;

            if (probability > 1 || probability < 0)
                throw new InvalidOperationException("invalid probability");

            var random = new Random();
            var doubleRandom = random.NextDouble();
            
            if (doubleRandom <= probability)  result = true;
            return result;
        }
    }
}
