namespace TImesheetTracker.ViewModels
{
    public interface IChannelViewModel
    {
        string Name { get; set; }

    }

    public class ChannelViewModel : IChannelViewModel
    {
        public string Name { get; set; }
    }
}
