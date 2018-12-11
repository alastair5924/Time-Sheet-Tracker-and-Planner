using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TImesheetTracker.Models.Reports
{
    public interface IReport<T>
    {
        IEnumerable<T> Reports { get; set; }
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }

        double GetTotalTimeSpent();
    }
}
