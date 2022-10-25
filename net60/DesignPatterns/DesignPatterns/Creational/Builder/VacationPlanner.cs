
using System;
using System.Collections.Generic;

namespace DesignPatterns.Creational.Builder
{
    public class VacationPlanner : IVacationPlannerBuilder
    {
        private DateTime[] _period;
        private string _vacationsTitle;

        public void BookHotel()
        {
            if (_period == null || _period.Length != 2)
                _vacationsTitle = "Undefined period. Please build your vacation.";
            else
                _vacationsTitle = $" Hotel reserved from {_period[0]} to {_period[1]}";
        }

        public void BuildVacation(DateTime start, DateTime end)
        {
            _period = new DateTime[2]{
                start,
                end
            };
        }

        public IDictionary<string, string> GetMyVacation()
        {
            if (_period == null || _period.Length != 2)
                return new Dictionary<string, string>
                    {
                        {  "error_msg", "Plan not started" }
                    };


            return new Dictionary<string, string>
            {
                {  "period_start", _period[0].ToShortDateString() },
                {  "period_end", _period[1].ToShortDateString() },
                { "title", _vacationsTitle }
            };
        }
    }
}
