using System;
using System.Collections.ObjectModel;
using System.Linq;

using Caliburn.Micro;

using TImesheetTracker.Providers;
using TImesheetTracker.Services;
using TImesheetTracker.Settings;

namespace TImesheetTracker.ViewModels
{
    public interface IMainWindowViewModel
    {
        ObservableCollection<IDaySummaryViewModel> CachedDays { get; set; }
        IPageViewModel CurrentPage { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }

        void ViewPlanner();
        void ViewReport();
        void ShowSettings();
        void Save();
        void DeleteDay(IDaySummaryViewModel delDay);
        void AddDay(IDaySummaryViewModel daySummaryViewModel);
    }

    public class MainWindowViewModel : PropertyChangedBase, IMainWindowViewModel
    {
        private readonly IViewModelProvider _viewModelProvider;
        private readonly IDataInterfaceProvider _dataInterfaceProvider;
        private readonly IReportProvider _reportProvider;
        private readonly IModelProvider _modelProvider;

        private IAppSettings _settings;
        private IPageViewModel _currentPage;
        private DateTime _endDate = DateTime.Now + TimeSpan.FromDays(14);
        private DateTime _startDate = DateTime.Now - TimeSpan.FromDays(14);

        public ObservableCollection<IDaySummaryViewModel> CachedDays { get; set; }

        public IPageViewModel CurrentPage
        {
            get => _currentPage;
            set
            {
                if (value != _currentPage && value != null)
                {
                    _currentPage = value;
                    NotifyOfPropertyChange(() => CurrentPage);
                }
            }
        }

        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                if (value != null)
                {
                    _startDate = value;
                    NotifyOfPropertyChange(() => StartDate);
                    if (CurrentPage is IReportsViewModel)
                    {
                        ViewReport();
                    }
                    else
                    {
                        CurrentPage = _viewModelProvider.GetPlannerViewModel(this, StartDate, EndDate);
                    }
                }
            }
        }

        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                if (value != null)
                {
                    _endDate = value;
                    NotifyOfPropertyChange(() => EndDate);
                    if (CurrentPage is IReportsViewModel)
                    {
                        ViewReport();
                    }
                    else
                    {
                        CurrentPage = _viewModelProvider.GetPlannerViewModel(this, StartDate, EndDate);
                    }
                }
            }
        }

        public MainWindowViewModel(IDataInterfaceProvider dataInterfaceProvider, IViewModelProvider viewModelProvider, IReportProvider reportProvider, IModelProvider modelProvider)
        {
            _dataInterfaceProvider = dataInterfaceProvider;
            _viewModelProvider = viewModelProvider;
            _reportProvider = reportProvider;
            _modelProvider = modelProvider;
            _settings = _dataInterfaceProvider.GetSettings();
            CachedDays = new ObservableCollection<IDaySummaryViewModel>(_viewModelProvider.GetDaySummaryViewModels());
            ViewPlanner();
        }

        public void ViewPlanner()
        {
            if (CurrentPage is IPlannerViewModel)
            {
                return;
            }
            CurrentPage = _viewModelProvider.GetPlannerViewModel(this, StartDate, EndDate) as IPageViewModel;
        }

        public async void ShowSettings()
        {
            IEditAppSettingsViewModel settings = _viewModelProvider.GetAppSettingsViewModel();
            await DialogService.ShowDialog(settings);
            if (settings.DataFileLocation != _settings.DataFileLocation || settings.ReportFileLocation != _settings.ReportFilesLocation)
            {
                _settings = _settings.SaveNewSettings(settings.DataFileLocation, settings.ReportFileLocation);
                LoadNewSettings();
            }
        }

        private void LoadNewSettings()
        {
            //Refresh the days to the new file selected
            CachedDays = new ObservableCollection<IDaySummaryViewModel>(_viewModelProvider.GetDaySummaryViewModels());
            //check the current Page for type
            if (CurrentPage is IPlannerViewModel)
            {
                //load new data to planner view
                CurrentPage = _viewModelProvider.GetPlannerViewModel(this, StartDate, EndDate);
            }
            else
            {
                //load new data to Report view
                CurrentPage = _viewModelProvider.GetReportViewModel(CachedDays.ToList(), Period.Month, StartDate, EndDate);
            }
        }

        public void ViewReport()
        {
            if (CurrentPage is IReportsViewModel)
            {
                return;
            }
            CurrentPage = _viewModelProvider.GetReportViewModel(CachedDays.ToList(), Period.Quater, StartDate.Date, EndDate.Date);
        }

        public async void Save()
        {
            ISaveContextViewModel saveContextViewModel = new SaveContextViewModel(_settings.DataFileLocation, _settings.ReportFilesLocation);
            await DialogService.ShowDialog(saveContextViewModel);
            _settings = _settings.SaveNewSettings(saveContextViewModel.DataLocation, saveContextViewModel.ReportLocation);
            if (saveContextViewModel.DataToSave || saveContextViewModel.ReportToSave)
            {
                SaveFiles(saveContextViewModel);
            }
        }

        public bool SaveFiles(ISaveContextViewModel saveContextViewModel)
        {
            if (saveContextViewModel.DataToSave)
            {
                _dataInterfaceProvider.SaveData(CachedDays.Distinct().ToList(), saveContextViewModel.DataLocation);
            }
            if (saveContextViewModel.ReportToSave)
            {
                var daySummaries = _modelProvider.GetDaySummaries(CachedDays.Where(s => s != null).Select(s => _modelProvider.GetDaySummary(s.Date, s.TimeAvailable, s.TimeSpent, new ObservableCollection<string>(s.Tasks.Select(t => t.Task).ToList()))), StartDate, EndDate);
                _dataInterfaceProvider.SaveReport(_reportProvider.GetQuaterSummary(daySummaries, StartDate, EndDate));
            }
            return true;
        }

        public void DeleteDay(IDaySummaryViewModel delDay)
        {
            CachedDays.Remove(CachedDays.Where(d => d.Date.Date == delDay.Date.Date).First());
        }

        public void AddDay(IDaySummaryViewModel daySummaryViewModel)
        {
            DeleteDay(daySummaryViewModel);
            CachedDays.Add(daySummaryViewModel);
        }
    }
}