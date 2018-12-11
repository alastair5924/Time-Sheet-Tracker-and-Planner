using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

using TImesheetTracker.Models;
using TImesheetTracker.Models.Reports;
using TImesheetTracker.Services;
using TImesheetTracker.Settings;
using TImesheetTracker.ViewModels;

namespace TImesheetTracker.Providers
{
    public interface IDataInterfaceProvider
    {
        IEnumerable<IDaySummary> LoadData();
        IEnumerable<IDaySummary> LoadDataFromRange(DateTime start, DateTime end);

        bool SaveData(List<IDaySummaryViewModel> daySummaries, string location);

        bool SaveReport<T>(IReport<T> report);
        bool SaveReport<T>(IReport<T> report, string location);

        IAppSettings LoadSettings();
        void SaveSettings(IAppSettings settings);
        IAppSettings GetSettings();
    }
    public class DataInterfaceProvider : IDataInterfaceProvider
    {
        private readonly ISerializerService _serializerService;
        private IAppSettings _appSettings;

        public DataInterfaceProvider(ISerializerService serializerService)
        {
            _serializerService = serializerService;
            _appSettings = LoadSettings();
        }

        public IEnumerable<IDaySummary> LoadData()
        {
            _appSettings = LoadSettings();
            string data = ReadFile(_appSettings.DataFileLocation);
            if (string.IsNullOrEmpty(data))
            {
                return new List<IDaySummary>();
            }
            return _serializerService.FromJson<List<IDaySummary>>(ReadFile(_appSettings.DataFileLocation));
        }

        public IEnumerable<IDaySummary> LoadDataFromRange(DateTime start, DateTime end)
        {
            return _serializerService.FromJson<List<IDaySummary>>(ReadFile(_appSettings.DataFileLocation))
                .Where(d => d.Date >= start && d.Date <= end);
        }

        public bool SaveData(List<IDaySummaryViewModel> daySummaries, string location)
        {
            if (!CheckExistance(location))
            {
                File.Create(location);
                Thread.Sleep(10);
            }
            List<IDaySummary> days = new List<IDaySummary>();
            foreach (IDaySummaryViewModel daySummaryViewModel in daySummaries)
            {
                days.Add(new DaySummary(daySummaryViewModel.Date, daySummaryViewModel.TimeAvailable, daySummaryViewModel.TimeSpent, daySummaryViewModel.Tasks.Where(t => t != null && t.Task != null).Select(t => t.Task).ToList()));
            }
            return WriteDateToFile(days, location);
        }

        private string ReadFile(string file)
        {
            if (CheckExistance(file))
            {
                using (StreamReader reader = new StreamReader(file))
                {
                    return reader.ReadToEnd();
                }
            }
            return null;
        }

        private bool CheckExistance(string file)
        {
            return File.Exists(file);
        }

        public bool SaveReport<T>(IReport<T> report)
        {
            return SaveReport(report, _appSettings.ReportFilesLocation);
        }

        public bool SaveReport<T>(IReport<T> report, string location)
        {
            return WriteToFile(report.ToString(), location);
        }

        public IAppSettings LoadSettings()
        {
            //Desktop
            IAppSettings settings = new AppSettings();

            //Laptop
            //IAppSettings settings = new AppSettings();
            _appSettings = settings;
            if (_appSettings != settings && settings != null)
            {
                _appSettings = settings;
            }
            return _appSettings;
        }

        private bool WriteDateToFile<T>(T data, string location)
        {
            return WriteToFile(_serializerService.ToJson(data), location);
        }

        public void SaveSettings(IAppSettings settings)
        {
            _appSettings = settings.SaveNewSettings(settings.DataFileLocation, settings.ReportFilesLocation);
        }

        private bool WriteToFile(string contents, string location)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(location, false))
                {
                    writer.Write(contents);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public IAppSettings GetSettings()
        {
            return _appSettings;
        }
    }
}
