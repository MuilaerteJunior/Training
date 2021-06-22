using System;
using DesignPatterns.Behavioral;

namespace DesignPatterns
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            StrategyUsage();
        }

        private static void StrategyUsage()
        {
            Console.WriteLine("Strategy demonstration");
            var a = new Strategy();

            var s1 = new Strategy1();
            var s2 = new Strategy2();
            
            Console.WriteLine("First strategy:");
            a.Use(s1);
            a.Execute();
            
            Console.WriteLine("Second strategy:");
            a.Use(s2);
            a.Execute();

            Console.WriteLine("");
        }
    }
}
