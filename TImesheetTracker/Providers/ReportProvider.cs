using System;
using System.Collections.Generic;
using System.Linq;

using TImesheetTracker.Models;
using TImesheetTracker.Models.Reports;

namespace TImesheetTracker.Providers
{
    public interface IReportProvider
    {
        IHalfYearReport GetHalfYearSummary(IEnumerable<IDaySummary> summaries, DateTime startDate, DateTime endDate);
        IMonthReport GetMonthSummary(IEnumerable<IDaySummary> summaries, DateTime startDate, DateTime endDate);
        IQuaterReport GetQuaterSummary(IEnumerable<IDaySummary> summaries, DateTime startDate, DateTime endDate);
        IWeekReport GetWeekSummary(IEnumerable<IDaySummary> summaries, DateTime startDate, DateTime endDate);
        IYearReport GetYearSummary(IEnumerable<IDaySummary> summaries, DateTime startDate, DateTime endDate);
    }

    public class ReportProvider : IReportProvider
    {
        public IWeekReport GetWeekSummary(IEnumerable<IDaySummary> summaries, DateTime startDate, DateTime endDate)
        {
            return new WeekReport(summaries.Where(d => d.Date.Date >= startDate && d.Date.Date <= endDate).Take(7));
        }

        public IMonthReport GetMonthSummary(IEnumerable<IDaySummary> summaries, DateTime startDate, DateTime endDate)
        {
            Dictionary<int, List<IDaySummary>> weeks = new Dictionary<int, List<IDaySummary>>();
            foreach (var day in summaries)
            {
                int week = (int)(day.Date.Day / 7.0);
                if (!weeks.ContainsKey(week))
                {
                    weeks.Add(week, new List<IDaySummary>());
                }
                weeks[week].Add(day);
            }

            List<IWeekReport> reports = new List<IWeekReport>(weeks.Where(w => w.Value.Count > 0).Select(w => GetWeekSummary(w.Value, w.Value.Min(d => d.Date).Date, w.Value.Max(d => d.Date).Date)));
            return new MonthReport(reports.Where(r => r.Reports != null));
        }

        public IQuaterReport GetQuaterSummary(IEnumerable<IDaySummary> summaries, DateTime startDate, DateTime endDate)
        {
            Dictionary<int, List<IDaySummary>> months = new Dictionary<int, List<IDaySummary>>();

            foreach (var day in summaries)
            {
                int month = day.Date.Month;
                if (!months.ContainsKey(month))
                {
                    months.Add(month, new List<IDaySummary>());
                }
                months[month].Add(day);
            }

            List<IMonthReport> reports = new List<IMonthReport>(months.Where(m => m.Value.Count > 0).Select(m => GetMonthSummary(m.Value, m.Value.Min(d => d.Date).Date, m.Value.Max(d => d.Date).Date)));
            return new QuaterReport(reports.Where(r => r.Reports != null).ToList());
        }

        public IHalfYearReport GetHalfYearSummary(IEnumerable<IDaySummary> summaries, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public IYearReport GetYearSummary(IEnumerable<IDaySummary> summaries, DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }
    }
}
