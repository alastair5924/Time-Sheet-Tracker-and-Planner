using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Caliburn.Micro;
using TImesheetTracker.Providers;

namespace TImesheetTracker.ViewModels
{
    public class MainWindowViewModel : PropertyChangedBase
    {
        private readonly IViewModelProvider _viewModelProvider;

        private IPageViewModel _currentPage;

        public IPageViewModel CurrentPage
        {
            get => _currentPage;
            set
            {
                if (value != _currentPage && value != null)
                {
                    _currentPage = value;
                    NotifyOfPropertyChange(() => CurrentPage);
                }
            }
        }

        public MainWindowViewModel(IViewModelProvider viewModelProvider)
        {
            _viewModelProvider = viewModelProvider;
            CurrentPage = viewModelProvider.GetPlannerViewModel("") as IPageViewModel;
        }

        public void ViewPlanner()
        {
            CurrentPage = _viewModelProvider.GetPlannerViewModel("") as IPageViewModel;
        }

        public void ViewReportFull()
        {
            CurrentPage = _viewModelProvider.GetReportViewModel(Period.Month, DateTime.Now);
        }
    }
}
