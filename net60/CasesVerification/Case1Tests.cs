using CasesVerification.Strings.PerformanceMeasurements;
using Xunit;

namespace CasesVerification;

public class Case1Tests
{
    [Fact]
    public void ValidateStringBuilderPerformance()
    {
        var swm = new StopWatchMeasure();

        var test = new TimeMeasures(swm, short.MaxValue);

        Console.WriteLine("StringBuilderVSStringConcatVSPlusPlus");
        test.StringBuilderVSStringConcatVSPlusPlus();

        Assert.Equal("StringBuilder", test.GetResults().OrderBy(a => a.Value).FirstOrDefault().Key);
    }


    [Fact]
    public void ValidateEqualsUsageInQuery()
    {
        var swm = new StopWatchMeasure();

        var test1 = new TimeMeasures(swm, short.MaxValue);
        Console.WriteLine("ToLowerInQueryVSIndexOf");
        test1.ToLowerInQueryVSIndexOf();

        Assert.Equal("ToLower()", test1.GetResults().OrderBy(a => a.Value).FirstOrDefault().Key);
    }
}

