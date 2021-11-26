using CasesVerification.Strings.DataGenerator;
using System.Text;

namespace CasesVerification.Strings.PerformanceMeasurements;
public class TimeMeasures
{
    private StringData data;
    private IPerformanceMeter _performanceMetter;
    public TimeMeasures(IPerformanceMeter meter)
    {
        data = new StringData();
        _performanceMetter = meter;
    }

    public TimeMeasures(IPerformanceMeter meter, short stringSize)
    {
        data = new StringData(stringSize);
        _performanceMetter = meter;
    }

    public void StringBuilderVSStringConcatVSPlusPlus()
    {
        //In this case ToList is important here to preserve the string content
        var content = data.GetData().ToList();
        _performanceMetter.MetricStart();
        var sBuilder = new StringBuilder();
        foreach (var item in content)
        {
            sBuilder.Append(item);
        }
        var sBuilderResult = sBuilder.ToString();
        _performanceMetter.MetricStop("StringBuilder");

        var sConcat = string.Empty;
        foreach (var item in content)
        {
            sConcat = String.Concat(sConcat, item);
        }
        _performanceMetter.MetricStop("String.Concat");

        var sPlusPlus = string.Empty;
        foreach (var item in content)
        {
            sPlusPlus += item;
        }
        _performanceMetter.MetricStop("sPlusPlus");

        if (!sPlusPlus.Equals(sBuilderResult) && !sBuilderResult.Equals(sConcat))
            throw new Exception("Inconsistent test.");
    }

    public List<KeyValuePair<string, decimal>> GetResults()
    {
        return _performanceMetter.GetResults();
    }

    public void ToLowerInQueryVSIndexOf()
    {
        //In this case ToList is important here to preserve the string content
        var content = data.GetData().ToList();

        _performanceMetter.MetricStart();
        var searchTerm = content[200];
        var foundWord = content.FirstOrDefault(a => a.ToLower() == searchTerm.ToLower());
        _performanceMetter.MetricStop("ToLower()");

        _performanceMetter.MetricStart();
        var searchTerm2 = content[320];
        var foundWord2 = content.FirstOrDefault(a => a.Equals(searchTerm2, StringComparison.OrdinalIgnoreCase));
        _performanceMetter.MetricStop("Equals()");

        _performanceMetter.MetricStart();
        var searchTerm3 = content[450];
        var foundWord3 = content.FirstOrDefault(a => a.IndexOf(searchTerm2, StringComparison.OrdinalIgnoreCase) > 0);
        _performanceMetter.MetricStop("IndexOf");
    }
}
