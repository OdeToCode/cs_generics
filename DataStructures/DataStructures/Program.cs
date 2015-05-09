using System;

namespace DataStructures
{
    class Program
    {      
        static void Main(string[] args)
        {            
            var buffer = new CircularBuffer<double>(capacity:3);
            buffer.ItemDiscarded += ItemDiscarded;            
            
            ProcessInput(buffer);
         
            buffer.Dump(d => Console.WriteLine(d));
            
            ProcessBuffer(buffer);
        }

        static void ItemDiscarded(object sender, 
            ItemDiscardedEventArgs<double> e)
        {
            Console.WriteLine("Buffer full. Discarding {0} New item is {1}",
                    e.ItemDiscarded, e.NewItem
                );
        }

      

        private static void ProcessBuffer(IBuffer<double> buffer)
        {
            var sum = 0.0;
            Console.WriteLine("Buffer: ");
            while (!buffer.IsEmpty)
            {
                sum += buffer.Read();
            }
            Console.WriteLine(sum);
        }

        private static void ProcessInput(IBuffer<double> buffer)
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
