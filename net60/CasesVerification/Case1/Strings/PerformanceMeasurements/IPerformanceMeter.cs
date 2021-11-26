namespace CasesVerification.Strings.PerformanceMeasurements;
public interface IPerformanceMeter
{
    void MetricStart();
    void MetricStop(string keyName);
    List<KeyValuePair<string, decimal>> GetResults();
}
