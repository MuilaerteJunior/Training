using System.Collections.Generic;

namespace PerformanceProject.Strings.PerformanceMeasurements
{
    public interface IPerformanceMeter
    {
        void MetricStart();
        void MetricStop(string keyName);
        List<KeyValuePair<string, decimal>> GetResults();
    }
}
