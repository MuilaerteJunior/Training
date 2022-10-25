
using System;
using System.Collections.Generic;

namespace DesignPatterns.Creational.Builder
{
    public interface IVacationPlannerBuilder
    {
        void BuildVacation(DateTime start, DateTime end);
        void BookHotel();
        IDictionary<string, string> GetMyVacation();
    }
}
