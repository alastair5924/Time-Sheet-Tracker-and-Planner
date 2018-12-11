using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TImesheetTracker.Models.Reports
{
    public interface IQuaterReport : IReport<IMonthReport>
    {

    }

    public class QuaterReport : IQuaterReport
    {
        public QuaterReport(List<IMonthReport> monthReports)
        {
            Reports = monthReports;
            Reports.OrderBy(m => m.StartDate);
            StartDate = Reports.First().StartDate;
            EndDate = Reports.Last().EndDate;
        }

        public QuaterReport(IEnumerable<IMonthReport> reports, DateTime startDate, DateTime endDate)
        {
            Reports = reports;
            StartDate = startDate;
            EndDate = endDate;
        }
        
        public IEnumerable<IMonthReport> Reports { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public double GetTotalTimeSpent()
        {
            return Reports.Sum(r => r.GetTotalTimeSpent());
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Quarterly Overview : {StartDate.ToShortDateString()} - {EndDate.ToShortDateString()} : Total Time Spent: {GetTotalTimeSpent()}\n");
            foreach (IMonthReport report in Reports)
            {
                sb.Append("\t" + report);
            }
            return sb.ToString();
        }
    }
}
