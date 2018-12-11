using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

using TImesheetTracker.Models;

namespace TImesheetTracker.Providers
{
    public interface IModelProvider
    {
        IEnumerable<IDaySummary> GetDaySummaries();
        IEnumerable<IDaySummary> GetDaySummaries(string channel);
        IEditAppSettings GetAppSettings();
        List<IDaySummary> GetDaySummaries(DateTime startDate, DateTime endDate);
        IDaySummary GetDaySummary(DateTime date, string timeAvailable, string timeSpent, ObservableCollection<string> tasks);
        IDaySummary GetDaySummary(DateTime date, string timeAvailable, string timeSpent, IEnumerable<string> tasks);

        IEnumerable<IDaySummary> GetDaySummaries(IEnumerable<IDaySummary> daySummaries, DateTime startDate, DateTime endDate);
    }

    public class ModelProvider : IModelProvider
    {
        private readonly IDataInterfaceProvider _dataInterfaceProvider;

        public ModelProvider(IDataInterfaceProvider dataInterfaceProvider)
        {
            _dataInterfaceProvider = dataInterfaceProvider;
        }

        public IEditAppSettings GetAppSettings()
        {
            return new EditAppSettings(_dataInterfaceProvider.GetSettings());
        }

        public IEnumerable<IDaySummary> GetDaySummaries()
        {
            return _dataInterfaceProvider.LoadData();
        }

        public IEnumerable<IDaySummary> GetDaySummaries(string channel)
        {
            return GetDaySummaries();
        }

        public List<IDaySummary> GetDaySummaries(DateTime startDate, DateTime endDate)
        {
            return GetDaySummaries().Where(d => d.Date >= startDate && d.Date <= endDate).ToList();
        }

        public IEnumerable<IDaySummary> GetDaySummaries(IEnumerable<IDaySummary> daySummaries, DateTime startDate, DateTime endDate)
        {
            return daySummaries.Where(d => d.Date >= startDate && d.Date <= endDate);
        }

        public IDaySummary GetDaySummary(DateTime date, string timeAvailable, string timeSpent, ObservableCollection<string> tasks)
        {
            return new DaySummary(date, timeAvailable, timeSpent, tasks.ToList());
        }

        public IDaySummary GetDaySummary(DateTime date, string timeAvailable, string timeSpent, IEnumerable<string> tasks)
        {
            return new DaySummary(date, timeAvailable, timeSpent, tasks.ToList());
        }
    }
}
