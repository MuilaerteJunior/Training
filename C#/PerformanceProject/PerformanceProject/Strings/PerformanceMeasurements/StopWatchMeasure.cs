using System.Collections.Generic;
using System.Diagnostics;

namespace PerformanceProject.Strings.PerformanceMeasurements
{
    public class StopWatchMeasure : IPerformanceMeter
    {
        private Stopwatch _sw;
        private List<KeyValuePair<string, decimal>> _result;

        public StopWatchMeasure()
        {
            _sw = new Stopwatch();
            _result = new List<KeyValuePair<string, decimal>>();
        }
        public List<KeyValuePair<string, decimal>> GetResults()
        {
            return _result;
        }

        public void MetricStart()
        {
            _sw.Start();
        }

        public void MetricStop(string keyName)
        {
            _sw.Stop();
            _result.Add(new KeyValuePair<string, decimal>(keyName, _sw.ElapsedMilliseconds));
            _sw.Restart();
        }
    }
}
