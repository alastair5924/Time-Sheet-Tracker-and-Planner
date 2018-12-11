using System;

using Caliburn.Micro;

using TImesheetTracker.Models;
using TImesheetTracker.Models.Reports;

namespace TImesheetTracker.ViewModels
{
    public enum Period
    {
        Week, Month, Quater, HalfYear, Year
    }
    public interface IReportsViewModel
    {
        string Report { get; }

        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }

        //void GenerateReport(string channel, Period period);
        //void GenerateReport(string channel, DateTime start, DateTime end, Period period);
    }

    public class ReportsViewModel<T> : PropertyChangedBase, IReportsViewModel, IPageViewModel
    {
        private readonly T _report;

        private DateTime _startDate;
        private DateTime _endDate;

        public ReportsViewModel(T report, Period period)
        {
            _report = report;

            switch (period)
            {
                case Period.Week:
                    IReport<IDaySummary> r1 = (IReport<IDaySummary>)report;
                    _startDate = r1.StartDate;
                    _endDate = r1.EndDate;
                    break;
                case Period.Month:
                    IReport<IWeekReport> r2 = (IReport<IWeekReport>)report;
                    _startDate = r2.StartDate;
                    _endDate = r2.EndDate;
                    break;
                case Period.Quater:
                    IReport<IMonthReport> r3 = (IReport<IMonthReport>)report;
                    _startDate = r3.StartDate;
                    _endDate = r3.EndDate;
                    break;
                case Period.HalfYear:
                    IReport<IQuaterReport> r4 = (IReport<IQuaterReport>)report;
                    _startDate = r4.StartDate;
                    _endDate = r4.EndDate;
                    break;
                case Period.Year:
                    IReport<IHalfYearReport> r5 = (IReport<IHalfYearReport>)report;
                    _startDate = r5.StartDate;
                    _endDate = r5.EndDate;
                    break;
            }
        }

        public string Report => _report.ToString();

        public DateTime StartDate
        {
            get => _startDate;
            set
            {
                if (value != null && value != _startDate)
                {
                    _startDate = value;
                    NotifyOfPropertyChange(() => StartDate);
                }
            }
        }

        public DateTime EndDate
        {
            get => _endDate;
            set
            {
                if (value != null && value != _endDate)
                {
                    _endDate = value;
                    NotifyOfPropertyChange(() => EndDate);
                }
            }
        }


    }
}
