using TImesheetTracker.Settings;

namespace TImesheetTracker.Models
{
    public interface IEditAppSettings
    {
        string DataFileLocation { get; set; }
        string ReportFileLocation { get; set; }
    }

    public class EditAppSettings : IEditAppSettings
    {
        public EditAppSettings(IAppSettings appSettings)
        {
            DataFileLocation = appSettings.DataFileLocation;
            ReportFileLocation = appSettings.ReportFilesLocation;
        }

        public string DataFileLocation { get; set; }
        public string ReportFileLocation { get; set; }
    }
}
