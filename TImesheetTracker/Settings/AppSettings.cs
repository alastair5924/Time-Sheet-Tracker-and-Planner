using System.Configuration;
using System.IO;

namespace TImesheetTracker.Settings
{
    public interface IAppSettings
    {
        string DataFileLocation { get; set; }
        string ReportFilesLocation { get; set; }

        IAppSettings SaveNewSettings(string dataFileLocation, string reportFilesLocation);
    }

    public class AppSettings : IAppSettings
    {
        public AppSettings()
        {
            string settingsLocation = ConfigurationManager.AppSettings["SettingsLocation"].ToString();
            using (StreamReader reader = new StreamReader(settingsLocation))
            {
                DataFileLocation = reader.ReadLine();
                ReportFilesLocation = reader.ReadLine();
            }
        }

        public AppSettings(string dataLocation, string reportLocation)
        {
            DataFileLocation = dataLocation;
            ReportFilesLocation = reportLocation;
            SaveNewSettings(dataLocation, reportLocation);
        }

        public IAppSettings SaveNewSettings(string dataLocaiton, string reportLocation)
        {
            DataFileLocation = dataLocaiton;
            ReportFilesLocation = reportLocation;
            string settingsLocation = ConfigurationManager.AppSettings["SettingsLocation"].ToString();
            using (StreamWriter writer = new StreamWriter(settingsLocation, false))
            {
                writer.WriteLine(dataLocaiton);
                writer.WriteLine(reportLocation);
            }
            return this;
        }

        public string DataFileLocation { get; set; }
        public string ReportFilesLocation { get; set; }
    }
}
