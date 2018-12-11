using System.Collections.Generic;
using System.Linq;

namespace TImesheetTracker.Models
{
    public interface IPlannerModel
    {
        IEnumerable<IDaySummary> Days { get; set; }
    }
    public class Planner : IPlannerModel
    {
        public Planner(IEnumerable<IDaySummary> days)
        {
            Days = days.ToList();
        }

        public IEnumerable<IDaySummary> Days { get; set; }
    }
}
