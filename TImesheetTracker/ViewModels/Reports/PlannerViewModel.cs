using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using Caliburn.Micro;

using TImesheetTracker.Providers;

namespace TImesheetTracker.ViewModels
{
    public interface IPlannerViewModel
    {
        ObservableCollection<IDaySummaryViewModel> Days { get; set; }
        IDaySummaryViewModel SelectedDay { get; set; }
        IDayCRUDViewModel DayCRUD { get; set; }
        INewDaySheetViewModel NewDay { get; set; }

        void CreateNewDay(INewDaySheetViewModel newDaySheetViewModel);
        void UpdateDay(IDayCRUDViewModel dayCRUDViewModel);
        void DeleteDay(IDayCRUDViewModel dayCRUDViewModel);
    }

    public class PlannerViewModel : PropertyChangedBase, IPlannerViewModel, IPageViewModel
    {
        private readonly IViewModelProvider _viewModelProvider;
        private readonly IMainWindowViewModel _parent;
        private readonly ObservableCollection<IDaySummaryViewModel> _originalDays;
        private readonly DateTime _startDate;
        private readonly DateTime _endDate;

        private ObservableCollection<IDaySummaryViewModel> _days;
        private IDaySummaryViewModel _selectedDay;
        private IDayCRUDViewModel _dayCRUD;
        private INewDaySheetViewModel _newDay;

        public PlannerViewModel(IMainWindowViewModel parent, IEnumerable<IDaySummaryViewModel> days, IViewModelProvider viewModelProvider)
        {
            _viewModelProvider = viewModelProvider;
            _parent = parent;
            _originalDays = new ObservableCollection<IDaySummaryViewModel>(days.OrderBy(d => d.Date));
            _days = _originalDays;
            if (_days.Count > 0)
            {
                _startDate = _days.First().Date;
                _endDate = _days.Last().Date;
                SelectedDay = Days.First();
            }
            NewDay = CreateDay();

        }

        public ObservableCollection<IDaySummaryViewModel> Days
        {
            get => _days;
            set
            {
                if (value != null)
                {
                    _days = value;
                    NotifyOfPropertyChange(() => Days);
                }
            }
        }

        public IDaySummaryViewModel SelectedDay
        {
            get => _selectedDay;
            set
            {
                //_parent.CachedDays.Remove(_selectedDay);
                _selectedDay = value;
                //_parent.CachedDays.Add(_selectedDay);
                DayCRUD = (_selectedDay != null) ? _viewModelProvider.GetDayCRUDViewModel(this, _selectedDay) : null;
                NotifyOfPropertyChange(() => SelectedDay);
            }
        }

        public IDayCRUDViewModel DayCRUD
        {
            get => _dayCRUD;
            set
            {
                _dayCRUD = value;
                NotifyOfPropertyChange(() => DayCRUD);
            }
        }

        public INewDaySheetViewModel NewDay
        {
            get => _newDay;
            set
            {
                if (value != null)
                {
                    _newDay = value;
                    NotifyOfPropertyChange(() => NewDay);
                }
            }
        }

        public void CreateNewDay(INewDaySheetViewModel newDaySheetViewModel)
        {
            if (Days.Any(d => d.Date.Date == newDaySheetViewModel.Date.Date))
            {
                //show error dialog
                //DialogService.ShowDialog(new ErrorDialog($"An entry hah laready been added with the date: {newDaySheetViewModel.Date.Date}\n"));
                return;
            }
            IDaySummaryViewModel dayVM = _viewModelProvider.GetDaySummaryViewModel(newDaySheetViewModel);
            Days.Add(dayVM);
            _parent.CachedDays.Add(dayVM);
            NewDay = CreateDay();
        }

        public void DeleteDay(IDayCRUDViewModel dayCRUDViewModel)
        {
            var delDay = _days.Where(d => d.Date.Date == DateTime.Parse(dayCRUDViewModel.Date))
                              .FirstOrDefault();
            _days.Remove(delDay);
            _parent.DeleteDay(delDay);
            var tempSelectedDay = Days.FirstOrDefault();
            SelectedDay = (Days.Count == 0) ? null : tempSelectedDay;
        }

        public void UpdateDay(IDayCRUDViewModel dayCRUDViewModel)
        {
            IDaySummaryViewModel daySummaryViewModel = _viewModelProvider.GetDaySummaryViewModel(dayCRUDViewModel);
            Days.Remove(Days.Where(d => d.Date.Date == daySummaryViewModel.Date.Date).First());
            Days.Add(daySummaryViewModel);
            _parent.AddDay(daySummaryViewModel);
            SelectedDay = _viewModelProvider.GetDaySummaryViewModel(dayCRUDViewModel);

        }

        private INewDaySheetViewModel CreateDay()
        {
            INewDaySheetViewModel newD = _viewModelProvider.GetNewDaySummaryViewModel(this);
            newD.Date = DateTime.Now.Date;
            return newD;
        }
    }
}