using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Caliburn.Micro;

using TImesheetTracker.Providers;

namespace TImesheetTracker.ViewModels
{
    public interface INewDaySheetViewModel
    {
        DateTime Date { get; set; }
        string TimeSpent { get; set; }
        string TimeAvailable { get; set; }
        ObservableCollection<ITaskViewModel> Tasks { get; set; }

        void CreateNewTask();
        void CreateNew();
    }
    public class NewDaySheetViewModel : PropertyChangedBase, INewDaySheetViewModel
    {
        private readonly IPlannerViewModel _parentViewModel;
        private readonly IViewModelProvider _viewModelProvider;

        private DateTime _date;
        private string _timeSpent;
        private string _timeAvailable;
        private ObservableCollection<ITaskViewModel> _tasks;

        public NewDaySheetViewModel(IViewModelProvider viewModelProvider, IPlannerViewModel parentViewModel, DateTime date, string timeAvailable, string timeSpent, List<ITaskViewModel> tasks)
        {
            _timeAvailable = timeSpent;
            _timeSpent = timeSpent;
            _tasks = new ObservableCollection<ITaskViewModel>(tasks);
            _viewModelProvider = viewModelProvider;
            _parentViewModel = parentViewModel;
        }

        public NewDaySheetViewModel(IViewModelProvider viewModelProvider, IPlannerViewModel parentViewModel, IDaySummaryViewModel selectedDay)
        {
            _timeAvailable = selectedDay.TimeSpent;
            _timeSpent = selectedDay.TimeSpent;
            _tasks = selectedDay.Tasks;
            _viewModelProvider = viewModelProvider;
            _parentViewModel = parentViewModel;
        }

        public string TimeSpent
        {
            get => _timeSpent;
            set
            {
                if (value != null)
                {
                    _timeSpent = value;
                    NotifyOfPropertyChange(() => TimeSpent);
                }
            }
        }

        public string TimeAvailable
        {
            get => _timeAvailable;
            set
            {
                if (value != null)
                {
                    _timeAvailable = value;
                    NotifyOfPropertyChange(() => TimeAvailable);
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

        public DateTime Date
        {
            get => _date;
            set
            {
                if (value != null)
                {
                    _date = value;
                    NotifyOfPropertyChange(() => Date);
                }
            }
        }

        public void CreateNew()
        {
            if (TimeAvailable == "")
            {
                return;
            }
            _parentViewModel.CreateNewDay(this);
        }

        public void CreateNewTask()
        {
            Tasks.Add(_viewModelProvider.GetTaskModel(""));
        }
    }
}
