using System.Collections.ObjectModel;

using Caliburn.Micro;

using TImesheetTracker.Providers;

namespace TImesheetTracker.ViewModels
{
    public interface IDayCRUDViewModel
    {
        string Date { get; set; }
        string TimeSpent { get; set; }
        string TimeAvailable { get; set; }
        ObservableCollection<ITaskViewModel> Tasks { get; set; }

        void CreateNewTask();
        void UpdateDay();
        void Delete();

    }

    public class DayCRUDViewModel : PropertyChangedBase, IDayCRUDViewModel
    {
        private readonly IPlannerViewModel _parent;
        private readonly IViewModelProvider _viewModelProvider;

        private string _date;
        private string _timeSpent;
        private string _timeAvailable;
        private ObservableCollection<ITaskViewModel> _tasks;



        public DayCRUDViewModel(IViewModelProvider viewModelProvider, IPlannerViewModel parent, IDaySummaryViewModel selectedDay)
        {
            _viewModelProvider = viewModelProvider;
            _date = selectedDay.DisplayDate;
            _timeAvailable = selectedDay.TimeAvailable;
            _timeSpent = selectedDay.TimeSpent;
            _tasks = selectedDay.Tasks;
            _parent = parent;
        }

        public string TimeSpent
        {
            get => _timeSpent;
            set
            {
                if (value != null)
                {
                    _timeSpent = value;
                    UpdateDay();
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
                    UpdateDay();
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
                    UpdateDay();
                    NotifyOfPropertyChange(() => Tasks);
                }
            }
        }

        public string Date
        {
            get => _date;
            set
            {
                if (value != null)
                {
                    _date = value;
                    UpdateDay();
                    NotifyOfPropertyChange(() => Date);
                }
            }
        }

        public void UpdateDay()
        {
            _parent.UpdateDay(this);
        }

        public void Delete()
        {
            _parent.DeleteDay(this);
        }

        public void CreateNewTask()
        {
            Tasks.Add(_viewModelProvider.GetTaskModel(""));
        }
    }
}
