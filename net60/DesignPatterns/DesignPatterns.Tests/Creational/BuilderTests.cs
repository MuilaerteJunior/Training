using Xunit;
using DesignPatterns.Creational.Builder;
using System;

namespace DesignPatterns.Tests.Creational
{
    public class BuilderTests
    {
        [Fact(DisplayName = "Builder example")]
        public void Validate_builder()
        {
            var act = new BuilderExample();
            var dtStart = DateTime.Now;
            var dtEnd = DateTime.Now.AddDays(15);
            var result = act.UseVacationPlannerBuilder(dtStart, dtEnd);

            Assert.Equal(dtStart.ToShortDateString(), result["period_start"]);
            Assert.Equal(dtEnd.ToShortDateString(), result["period_end"]);
        }
    }
}
