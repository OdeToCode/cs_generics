using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tips
{
    class MathProblems
    {
        static void DoIt(string[] args)
        {
            var numbers = new double[] { 1, 2, 3, 4, 5, 6 };
            var result = SampledAverage(numbers);
            Console.WriteLine(result);
        }

        private static double SampledAverage(double[] numbers)
        {
            var count = 0;
            var sum = 0.0;
            for (int i = 0; i < numbers.Length; i += 2)
            {
                sum += numbers[i];
                count += 1;
            }
            return sum / count;
        }
    }
}
