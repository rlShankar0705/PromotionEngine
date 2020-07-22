using RuleEnginePattern;
using System;

namespace RuleEngineApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var active = new DiscountCalculator();
            var s1 = active.CalculateDiscountPercentage("A,B,C"); // 100 - Pass
            Console.WriteLine("Total = {0}", s1);
            var s2 = active.CalculateDiscountPercentage("A,A,A,A,A,B,B,B,B,B,C"); // 370 - Pass
            Console.WriteLine("Total = {0}", s2);
            var s3 = active.CalculateDiscountPercentage("A,A,A,,B,B,B,B,B,C,D"); // 280 - Pass
            Console.WriteLine("Total = {0}", s3);
            Console.ReadKey();
        }
    }
}
