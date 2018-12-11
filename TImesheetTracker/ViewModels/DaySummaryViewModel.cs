using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Caliburn.Micro;

using TImesheetTracker.Models;
using TImesheetTracker.Providers;

namespace TImesheetTracker.ViewModels
{
    public interface IDaySummaryViewModel
    {
        DateTime Date { get; set; }
        string TimeAvailable { get; set; }
        string TimeSpent { get; set; }
        ObservableCollection<ITaskViewModel> Tasks { get; set; }
        bool IsToday { get; set; }
        string DisplayDate { get; set; }

        //void ShowEditDialog(IDaySummaryViewModel daySummaryViewModel);
    }

    public class DaySummaryViewModel : PropertyChangedBase, IDaySummaryViewModel
    {
        private readonly IViewModelProvider _viewModelProvider;

        private string _timeSpent;
        private ObservableCollection<ITaskViewModel> _tasks;
        private string _timeAvailable;
        private bool _isToday;
        private DateTime _date;
        private string _displayDate;

        public DaySummaryViewModel(DateTime date, string timeAvailable, string timeSpent, List<ITaskViewModel> tasks)
        {
            _date = date;
            _displayDate = _date.Date.ToShortDateString();
            _timeAvailable = timeAvailable;
            _timeSpent = timeSpent;
            _tasks = new ObservableCollection<ITaskViewModel>(tasks);
        }

        public DaySummaryViewModel(IViewModelProvider viewModelProvider, IDaySummary daySummary)
        {
            _viewModelProvider = viewModelProvider;
            _date = daySummary.Date;
            _displayDate = _date.Date.ToShortDateString();
            _timeAvailable = daySummary.TimeAvailable;
            _timeSpent = daySummary.TimeSpent;
            _tasks = new ObservableCollection<ITaskViewModel>(_viewModelProvider.GetTaskModels(daySummary.Tasks));
            _isToday = Date == DateTime.Now.Date;
        }

        //public async void ShowEditDialog(IDaySummaryViewModel daySummaryViewModel)
        //{
        //    IEditDaySummaryViewModel editViewModel = new EditDaySummaryViewModel(daySummaryViewModel);
        //    await DialogService.ShowDialog(editViewModel);
        //    TimeAvailable = editViewModel.TimeAvailable;
        //    TimeSpent = editViewModel.TimeSpent;
        //    Tasks = editViewModel.Tasks;
        //}


        public DateTime Date
        {
            get => _date;
            set
            {
                if (value != _date)
                {
                    _date = value;
                    NotifyOfPropertyChange(() => Date);
                }
            }
        }

        public string TimeAvailable
        {
            get => _timeAvailable;
            set
            {
                if (value != _timeAvailable)
                {
                    _timeAvailable = value;
                    NotifyOfPropertyChange(() => TimeAvailable);

                }
            }
        }

        public string TimeSpent
        {
            get => _timeSpent;
            set
            {
                if (value != _timeSpent)
                {
                    _timeSpent = value;
                    NotifyOfPropertyChange(() => TimeSpent);

                }
            }
        }

        public ObservableCollection<ITaskViewModel> Tasks
        {
            get => _tasks;
            set
            {
                if (value != null)
                {
                    _tasks = value;
                    NotifyOfPropertyChange(() => Tasks);
                }
            }
        }

        public bool IsToday
        {
            get => Date.Date == DateTime.Now.Date;
            set
            {
                _isToday = value;
                NotifyOfPropertyChange(() => IsToday);
            }
        }

        public string DisplayDate
        {
            get => _displayDate;
            set
            {
                if (value != _displayDate)
                {
                    _displayDate = value;
                    Date = DateTime.Parse(_displayDate);
                    NotifyOfPropertyChange(() => DisplayDate);
                }
            }
        }
    }
}