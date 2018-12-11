using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TImesheetTracker.Models;
using TImesheetTracker.Models.ReportModels;
using TImesheetTracker.ViewModels;

namespace TImesheetTracker.Providers
{
    public interface IReportProvider
    {
        IHalfYearReport GetHalfYearSummary(IEnumerable<IDaySummary> summaries, Period period);
        IMonthReport GetMonthSummary(IEnumerable<IDaySummary> summaries, Period period);
        IQuaterReport GetQuaterSummary(IEnumerable<IDaySummary> summaries, Period period);
        IWeekReport GetWeekSummary(IEnumerable<IDaySummary> summaries, Period period);
        IYearReport GetYearSummary(IEnumerable<IDaySummary> summaries, Period period);
    }

    public class ReportProvider : IReportProvider
    {
        public IWeekReport GetWeekSummary(IEnumerable<IDaySummary> summaries, Period period)
        {
            return new WeekReport(summaries);
        }

        public IMonthReport GetMonthSummary(IEnumerable<IDaySummary> summaries, Period period)
        {


        }

        public IQuaterReport GetQuaterSummary(IEnumerable<IDaySummary> summaries, Period period)
        {
            throw new NotImplementedException();

        }

        public IHalfYearReport GetHalfYearSummary(IEnumerable<IDaySummary> summaries, Period period)
        {
            throw new NotImplementedException();

        }

        public IYearReport GetYearSummary(IEnumerable<IDaySummary> summaries, Period period)
        {
            throw new NotImplementedException();
        }
    }
}
