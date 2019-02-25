using System;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncTest
{
    public enum TaskResult
    {
        Success,
        Failure
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, world!");
            StartAsyncMethod(() => { Console.WriteLine("Após execução!"); });
            Console.WriteLine("Finish!");
            Console.ReadKey();
        }
        
        private static async void StartAsyncMethod(Action actionBeExecutedAfter)
        {
            var a = await Task.Run(TaskBePerformed());
            ResultTreatment(a);
            actionBeExecutedAfter();
        }

        private static void ResultTreatment(TaskResult a)
        {
            if (a == TaskResult.Success)
            {
                Console.WriteLine("Success!");
            } else if (a == TaskResult.Failure)
            {
                Console.WriteLine("Fail");
            }
        }

        private static Func<TaskResult> TaskBePerformed()
        {
            return () =>
            {
                Thread.Sleep(2000);                
                return TaskResult.Success;
            };
        }
    }
}