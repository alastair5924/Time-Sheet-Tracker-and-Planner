namespace TImesheetTracker.Models
{
    public interface ITaskModel
    {
        string Task { get; set; }
    }

    public class TaskModel : ITaskModel
    {
        public TaskModel(string task)
        {
            Task = task;
        }
        public string Task { get; set; }
    }
}
