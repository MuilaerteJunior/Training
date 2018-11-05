using PerformanceProject.Strings.PerformanceMeasurements;
using System;
using System.Linq;

namespace PerformanceProject
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(string.Format("{0}{1}{2}{1}{0}", string.Join("*",Enumerable.Repeat("*",40)),Environment.NewLine, "Developed by Muilaerte Júnior. Github: https://github.com/MuilaerteJunior/"));

            var swm = new StopWatchMeasure();

            var test = new TimeMeasures(swm, short.MaxValue);

            Console.WriteLine("StringBuilderVSStringConcatVSPlusPlus");
            test.StringBuilderVSStringConcatVSPlusPlus();

            Console.WriteLine("ToLowerInQueryVSIndexOf");
            test.ToLowerInQueryVSIndexOf();

            foreach (var result in test.GetResults())
            {
                Console.WriteLine(result.Key + ":" + result.Value);
            }

            Console.ReadKey();
        }
    }
}
