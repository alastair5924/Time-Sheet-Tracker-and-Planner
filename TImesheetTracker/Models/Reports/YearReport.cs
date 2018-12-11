using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TImesheetTracker.Models.Reports
{
    public interface IYearReport : IReport<IQuaterReport>
    {

    }
    public class YearReport : IYearReport
    {
        public YearReport(IEnumerable<IQuaterReport> reports)
        {
            Reports = reports;
            Reports.OrderBy(m => m.StartDate);
            StartDate = Reports.First().StartDate;
            EndDate = Reports.Last().EndDate;
        }

        public YearReport(IEnumerable<IQuaterReport> reports, DateTime startDate, DateTime endDate)
        {
            Reports = reports;
            StartDate = startDate;
            EndDate = endDate;
        }

        public IEnumerable<IQuaterReport> Reports { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public double GetTotalTimeSpent()
        {
            return Reports.Sum(r => r.GetTotalTimeSpent());
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Year Overview : {StartDate} - {EndDate} : Total Time Spent: {GetTotalTimeSpent()}");
            foreach (IWeekReport report in Reports)
            {
                sb.Append(report);
            }
            return sb.ToString();
        }
    }
}
