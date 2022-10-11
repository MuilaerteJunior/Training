using System;

namespace DesignPatterns.Behavioral.Strategy
{
    public class Strategy2 : IStrategy {
        public void Execute()
        {
            Console.WriteLine("I'm from Strategy 2!");
        }
    }
}