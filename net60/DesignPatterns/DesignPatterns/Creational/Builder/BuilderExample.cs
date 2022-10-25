
using System;
using System.Collections.Generic;

namespace DesignPatterns.Creational.Builder
{
    public class BuilderExample {
        public IDictionary<string,string> UseVacationPlannerBuilder(DateTime dtStart, DateTime dtEnd)
        {
            var client = new VacationPlanner();
            client.BuildVacation(dtStart, dtEnd);
            client.BookHotel();
            var result = client.GetMyVacation();
            return result;
        }
    }
}
