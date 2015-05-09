using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tips
{
    public enum Steps
    {
        Step1,
        Step2,
        Step3
    }


    public static class StringExtensions
    {
        public static TEnum ParseEnum<TEnum>(this string value)
            where TEnum : struct
        {
            return (TEnum)Enum.Parse(typeof(TEnum), value);
        }
    }

    class Demo
    {
        static void DoIt()
        {
            var input = "Step1";
            var value = input.ParseEnum<Steps>();
            Console.WriteLine(value);

            //(Steps)Enum.Parse(typeof(Steps), input);

        }
    }
}
