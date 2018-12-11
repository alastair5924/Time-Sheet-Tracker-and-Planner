using Caliburn.Micro;

namespace TImesheetTracker.ViewModels
{
    public interface ITaskViewModel
    {
        string Task { get; set; }
    }
    public class TaskViewModel : PropertyChangedBase, ITaskViewModel
    {
        private string _task;

        public TaskViewModel(string task)
        {
            _task = task;
        }
        public string Task
        {
            get => _task;
            set
            {
                _task = value;
                NotifyOfPropertyChange(() => Task);
            }
        }
    }
}
