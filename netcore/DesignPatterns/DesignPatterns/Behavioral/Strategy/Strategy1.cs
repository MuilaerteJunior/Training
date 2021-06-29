using System;

namespace DesignPatterns.Behavioral.Strategy
{
    public class Strategy1 : IStrategy
    {
        public void Execute()
        {
            Console.WriteLine("I'm from Strategy 1!");
        }
    }
}