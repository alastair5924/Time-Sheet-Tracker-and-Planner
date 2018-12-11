using System.Collections.Generic;


namespace TImesheetTracker.Models
{
    public interface IChannel
    {
        List<IDaySummary> Days { get; set; }
    }

    public class Channel : IChannel
    {
        private List<IDaySummary> _days;

        public Channel(List<IDaySummary> days)
        {
            _days = days;
        }

        public List<IDaySummary> Days
        {
            get => _days;
            set
            {
                if (value != null)
                {
                    _days = value;
                }
            }
        }

    }
}
