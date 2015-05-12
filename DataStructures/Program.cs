using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{

    class Program
    {
        static void Main(string[] args)
        {
            var buffer = new CircularBuffer();

                  
            ProcessInput(buffer);       
            ProcessBuffer(buffer);
        }

        private static void ProcessBuffer(CircularBuffer buffer)
        {
            var sum = 0.0;
            Console.WriteLine("Buffer: ");
            while (!buffer.IsEmpty)
            {
                sum += buffer.Read();
            }
            Console.WriteLine(sum);
        }

        private static void ProcessInput(CircularBuffer buffer)
        {
            while (true)
            {
                var value = 0.0;
                var input = Console.ReadLine();

                if (double.TryParse(input, out value))
                {
                    buffer.Write(value);
                    continue;
                }
                break;
            }
        }
    }
}
