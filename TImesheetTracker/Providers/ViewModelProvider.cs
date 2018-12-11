using System;
using System.Collections.Generic;
using System.Linq;

using TImesheetTracker.Models;
using TImesheetTracker.Models.Reports;
using TImesheetTracker.ViewModels;

namespace TImesheetTracker.Providers
{
    public interface IViewModelProvider
    {
        IEnumerable<IDaySummaryViewModel> GetDaySummaryViewModels();
        IDaySummaryViewModel GetDaySummaryViewModel(IDaySummary daySummary);

        IPageViewModel GetReportViewModel(List<IDaySummaryViewModel> days, Period period, DateTime startDate, DateTime endDate);

        IEditAppSettingsViewModel GetAppSettingsViewModel();
        INewDaySheetViewModel GetNewDaySummaryViewModel(IPlannerViewModel parent);
        IDayCRUDViewModel GetDayCRUDViewModel(IPlannerViewModel plannerViewModel, IDaySummaryViewModel selectedDay);
        IDaySummaryViewModel GetDaySummaryViewModel(INewDaySheetViewModel newDaySheetViewModel);
        IDaySummaryViewModel GetDaySummaryViewModel(IDayCRUDViewModel dayCRUDViewModel);
        IPageViewModel GetPlannerViewModel(IMainWindowViewModel mainWindowViewModel, DateTime startDate, DateTime endDate);
        IEnumerable<ITaskViewModel> GetTaskModels(List<string> tasks);
        ITaskViewModel GetTaskModel(string description);
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

        public IEditAppSettingsViewModel GetAppSettingsViewModel()
        {
            return new EditAppSettingsViewModel(_modelProvider.GetAppSettings());
        }

        public IDayCRUDViewModel GetDayCRUDViewModel(IPlannerViewModel plannerViewModel, IDaySummaryViewModel day)
        {
            return new DayCRUDViewModel(this, plannerViewModel, day);
        }

        public IDaySummaryViewModel GetDaySummaryViewModel(IDaySummary daySummary)
        {
            return new DaySummaryViewModel(this, daySummary);
        }

        public IDaySummaryViewModel GetDaySummaryViewModel(INewDaySheetViewModel newDaySheetViewModel)
        {
            return new DaySummaryViewModel(newDaySheetViewModel.Date, newDaySheetViewModel.TimeAvailable, newDaySheetViewModel.TimeSpent, newDaySheetViewModel.Tasks.ToList());
        }

        public IDaySummaryViewModel GetDaySummaryViewModel(IDayCRUDViewModel dayCRUDViewModel)
        {
            return new DaySummaryViewModel(DateTime.Parse(dayCRUDViewModel.Date), dayCRUDViewModel.TimeAvailable, dayCRUDViewModel.TimeSpent, dayCRUDViewModel.Tasks.ToList());
        }

        public IEnumerable<IDaySummaryViewModel> GetDaySummaryViewModels()
        {
            foreach (IDaySummary day in _modelProvider.GetDaySummaries())
            {
                yield return GetDaySummaryViewModel(day);
            }
        }

        public INewDaySheetViewModel GetNewDaySummaryViewModel(IPlannerViewModel parent)
        {
            return new NewDaySheetViewModel(this, parent, DateTime.Now.Date, string.Empty, string.Empty, new List<ITaskViewModel> { GetTaskModel(string.Empty), GetTaskModel(string.Empty), GetTaskModel(string.Empty) });
        }

        public IPageViewModel GetPlannerViewModel(IMainWindowViewModel mainWindowViewModel, DateTime startDate, DateTime endDate)
        {
            return new PlannerViewModel(mainWindowViewModel, mainWindowViewModel.CachedDays.Where(vm => vm != null).Where(vm => vm.Date >= startDate && vm.Date <= endDate), this);
        }

        public IPageViewModel GetReportViewModel(List<IDaySummaryViewModel> days, Period period, DateTime startDate, DateTime endDate)
        {
            var daymodels = _modelProvider.GetDaySummaries(days.Where(d => d != null).Select(d => _modelProvider.GetDaySummary(d.Date, d.TimeAvailable, d.TimeSpent, d.Tasks.Select(t => t.Task).ToList())), startDate, endDate);
            switch (period)
            {
                case Period.Week:
                    return new ReportsViewModel<IWeekReport>(_reportProvider.GetWeekSummary(daymodels, startDate, endDate), Period.Week);

                case Period.Month:
                    return new ReportsViewModel<IMonthReport>(_reportProvider.GetMonthSummary(daymodels, startDate, endDate), Period.Month);

                case Period.Quater:
                    return new ReportsViewModel<IQuaterReport>(_reportProvider.GetQuaterSummary(daymodels, startDate, endDate), Period.Quater);

                case Period.HalfYear:
                    return new ReportsViewModel<IHalfYearReport>(_reportProvider.GetHalfYearSummary(daymodels, startDate, endDate), Period.Quater);

                case Period.Year:
                    return new ReportsViewModel<IYearReport>(_reportProvider.GetYearSummary(daymodels, startDate, endDate), Period.Quater);

                default:
                    return null;
            }
        }

        public ITaskViewModel GetTaskModel(string description)
        {
            return new TaskViewModel("");
        }

        public IEnumerable<ITaskViewModel> GetTaskModels(List<string> tasks)
        {
            foreach (string task in tasks)
            {
                yield return new TaskViewModel(task);
            }
        }
    }
}