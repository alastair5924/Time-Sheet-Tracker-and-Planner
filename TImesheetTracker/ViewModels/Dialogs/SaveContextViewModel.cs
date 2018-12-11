using Caliburn.Micro;

namespace TImesheetTracker.ViewModels
{
    public interface ISaveContextViewModel
    {
        bool ReportToSave { get; set; }
        bool DataToSave { get; set; }
        string ReportLocation { get; set; }
        string DataLocation { get; set; }
    }
    public class SaveContextViewModel : PropertyChangedBase, ISaveContextViewModel
    {
        private bool _report;
        private bool _data;
        private string _reportLocation;
        private string _dataLocation;

        public bool ReportToSave
        {
            get => _report;
            set
            {
                _report = value;
                NotifyOfPropertyChange(() => ReportToSave);
            }
        }

        public bool DataToSave
        {
            get => _data;
            set
            {
                _data = value;
                NotifyOfPropertyChange(() => DataToSave);
            }
        }

        public string ReportLocation
        {
            get => _reportLocation;
            set
            {
                _reportLocation = value;
                NotifyOfPropertyChange(() => ReportLocation);
            }
        }

        public string DataLocation
        {
            get => _dataLocation;
            set
            {
                _dataLocation = value;
                NotifyOfPropertyChange(() => DataLocation);
            }
        }

        public SaveContextViewModel(string dataLocation, string reportLocation)
        {
            DataLocation = dataLocation;
            ReportLocation = reportLocation;
        }
    }
}