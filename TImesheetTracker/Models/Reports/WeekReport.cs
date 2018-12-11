using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TImesheetTracker.Models.Reports
{
    public interface IWeekReport : IReport<IDaySummary>
    {

    }

    public class WeekReport : IWeekReport
    {
        public WeekReport(IEnumerable<IDaySummary> days)
        {
            if (days.Count() == 0)
            {
                return;
            }
            Reports = days;
            Reports.OrderBy(d => d.Date);
            StartDate = Reports.First().Date;
            EndDate = Reports.Last().Date;
        }
        public WeekReport(IEnumerable<IDaySummary> day, DateTime startDate, DateTime endDate)
        {
            Reports = day;
            StartDate = startDate;
            EndDate = endDate;
        }

        public IEnumerable<IDaySummary> Reports { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public double GetTotalTimeSpent()
        {
            if (Reports == null)
            {
                return 0;
            }
            return Reports.Sum(r => double.Parse((r.TimeSpent == "") ? "0" : r.TimeSpent));
        }

        public override string ToString()
        {
            if (Reports == null)
            {
                return "";
            }
            StringBuilder sb = new StringBuilder();
            sb.Append($"Week Overview : {StartDate.ToShortDateString()} - {EndDate.ToShortDateString()} : Total Time Spent: {GetTotalTimeSpent()}\n\n");
            foreach (IDaySummary day in Reports)
            {
                sb.Append($"\t\t\tDay Overview : {day.Date.ToShortDateString()} - Time Spent: {double.Parse((day.TimeSpent == "") ? "0" : day.TimeSpent)}\n");
                sb.Append("\t\t\tTasks:\n");
                foreach (string task in day.Tasks)
                {
                    if (string.IsNullOrEmpty(task))
                    {
                        continue;
                    }
                    sb.Append($"\t\t\t\t{task}\n");
                }
                sb.Append("\n");
            }
            sb.Append("\n");
            return sb.ToString();
        }
    }
}
