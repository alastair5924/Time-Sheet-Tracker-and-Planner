using Caliburn.Micro;

using TImesheetTracker.Models;
using TImesheetTracker.Settings;

namespace TImesheetTracker.ViewModels
{
    public interface IEditAppSettingsViewModel
    {
        string DataFileLocation { get; set; }
        string ReportFileLocation { get; set; }

        void SaveSettings(string dataLocation, string reportLocaiton);
        void OpenFileDialog(object type);
    }
    public class EditAppSettingsViewModel : PropertyChangedBase, IEditAppSettingsViewModel
    {
        private IAppSettings _appSettings;

        private string _dataFileLocation;
        private string _reportFilesLocation;

        public EditAppSettingsViewModel(string dataFileLocation)
        {
            _dataFileLocation = dataFileLocation;
        }

        public EditAppSettingsViewModel(IEditAppSettings editAppSettings)
        {
            _dataFileLocation = editAppSettings.DataFileLocation;
            _reportFilesLocation = editAppSettings.ReportFileLocation;
        }

        public EditAppSettingsViewModel(IAppSettings appSettings)
        {
            _appSettings = appSettings;
            _dataFileLocation = _appSettings.DataFileLocation;
        }

        public string DataFileLocation
        {
            get => _dataFileLocation;

            set
            {
                if (value != null)
                {
                    _dataFileLocation = value;
                    NotifyOfPropertyChange(() => DataFileLocation);
                }
            }
        }

        public string ReportFileLocation
        {
            get => _reportFilesLocation;

            set
            {
                if (value != null)
                {
                    _reportFilesLocation = value;
                    NotifyOfPropertyChange(() => ReportFileLocation);
                }
            }
        }

        public void OpenFileDialog(object type)
        {
            Microsoft.Win32.OpenFileDialog openFileDialog = new Microsoft.Win32.OpenFileDialog()
            {
                Multiselect = false,
                Filter = "txt Files (*.txt)|*.txt",
                CheckFileExists = true,
                DefaultExt = "*.txt"

            };
            switch (type)
            {
                case "0":
                    {
                        openFileDialog.Title = "Open Data File...";
                        openFileDialog.InitialDirectory = @"D:\OneDrive\Work\Tracker\_Data";
                        if (openFileDialog.ShowDialog().Value)
                        {
                            DataFileLocation = openFileDialog.FileName;
                        }
                        break;
                    }
                case "1":
                    {
                        openFileDialog.Title = "Open Report File...";
                        openFileDialog.InitialDirectory = @"D:\OneDrive\Work\Tracker\_Reports";
                        if (openFileDialog.ShowDialog().Value)
                        {
                            ReportFileLocation = openFileDialog.FileName;
                        }
                        break;
                    }
            }
        }

        public void SaveSettings(string dataLocation, string reportLocaiton)
        {
            _appSettings = _appSettings.SaveNewSettings(dataLocation, reportLocaiton);
            _dataFileLocation = _appSettings.DataFileLocation;
        }
    }
}
