using System;
using System.Collections.Generic;

namespace TImesheetTracker.Models
{
    public interface IDaySummary
    {
        DateTime Date { get; set; }
        string TimeAvailable { get; set; }
        string TimeSpent { get; set; }
        List<string> Tasks { get; set; }
    }

    public class DaySummary : IDaySummary
    {
        public DaySummary()
        {
            Tasks = new List<string>();
        }

        public DaySummary(DateTime date, string timeAvailable, string timeSpent, List<string> list) : this()
        {
            Date = date;
            TimeAvailable = timeAvailable;
            TimeSpent = timeSpent;
            Tasks = list;
        }

        public DateTime Date { get; set; }
        public string TimeAvailable { get; set; }
        public string TimeSpent { get; set; }
        public List<string> Tasks { get; set; }
    }
}
