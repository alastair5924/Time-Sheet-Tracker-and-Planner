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
    public interface IViewModelProvider
    {
        IEnumerable<IDaySummaryViewModel> GetDaySummaryViewModels();
        IDaySummaryViewModel GetDaySummaryViewModel(IDaySummary daySummary);
        IPlannerViewModel GetPlannerViewModel(string channel);
        IPageViewModel GetReportViewModel(Period period, DateTime startDate);
    }
    public class ViewModelProvider : IViewModelProvider
    {
        private readonly IModelProvider _modelProvider;
        private readonly IReportProvider _reportProvider;

        public ViewModelProvider(IModelProvider modelProvider, IReportProvider reportProvider)
        {
            _modelProvider = modelProvider;
            _reportProvider = reportProvider;
        }

        public IDaySummaryViewModel GetDaySummaryViewModel(IDaySummary daySummary)
        {
            return new DaySummaryViewModel(daySummary);
        }

        public IEnumerable<IDaySummaryViewModel> GetDaySummaryViewModels()
        {
            foreach (IDaySummary day in _modelProvider.GetDaySummaries())
            {
                yield return GetDaySummaryViewModel(day);
            }
        }

        public IPlannerViewModel GetPlannerViewModel(string channel)
        {
            return new PlannerViewModel(GetDaySummaryViewModels());
        }

        public IPageViewModel GetReportViewModel(Period period, DateTime startDate)
        {
            IEnumerable<IDaySummary> days = _modelProvider.GetDaySummaries().Where(d => d.Date <= startDate);

            switch (period)
            {
                case Period.Week:
                    return new ReportsViewModel<IWeekReport>(_reportProvider.GetWeekSummary(days, Period.Week));  
                    
                case Period.Month:
                    return new ReportsViewModel<IMonthReport>(_reportProvider.GetMonthSummary(days,Period.Month));

                case Period.Quater:
                    return new ReportsViewModel<IQuaterReport>(_reportProvider.GetQuaterSummary(days, Period.Quater));

                case Period.HalfYear:
                    return new ReportsViewModel<IHalfYearReport>(_reportProvider.GetHalfYearSummary(days, Period.HalfYear));

                case Period.Year:
                    return new ReportsViewModel<IYearReport>(_reportProvider.GetYearSummary(days, Period.Year));

                default:
                    return null;
            }
        }
    }
}