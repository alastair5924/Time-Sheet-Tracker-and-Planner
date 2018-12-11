using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TImesheetTracker.Models.Reports
{
    public interface IMonthReport : IReport<IWeekReport>
    {
    }

    public class MonthReport : IMonthReport
    {
        public MonthReport(IEnumerable<IWeekReport> reports)
        {
            if (reports.Count() == 0)
            {
                return;
            }
            Reports = reports;
            Reports.OrderBy(d => d.StartDate);
            StartDate = Reports.First().StartDate;
            EndDate = Reports.Last().EndDate;
        }

        public MonthReport(DateTime startDate, DateTime endDate, List<IWeekReport> reports)
        {
            StartDate = startDate;
            EndDate = endDate;
            Reports = reports;
        }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public IEnumerable<IWeekReport> Reports { get; set; }

        public double GetTotalTimeSpent()
        {

            if (Reports != null)
            {
                return Reports.Where(r => r.Reports != null).Sum(r => r.GetTotalTimeSpent());
            }
            return 0.0;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Month Overview : {StartDate.ToShortDateString()} - {EndDate.ToShortDateString()} : Total Time Spent: {GetTotalTimeSpent()}\n");
            if (Reports == null)
            {
                return sb.ToString();
            }
            foreach (IWeekReport report in Reports)
            {
                sb.Append("\t\t" + report);
            }
            return sb.ToString();
        }
    }
}
