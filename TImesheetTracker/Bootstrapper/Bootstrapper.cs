using System;
using System.Windows;

using Caliburn.Micro;

using TImesheetTracker.Providers;
using TImesheetTracker.Services;
using TImesheetTracker.ViewModels;

namespace TImesheetTracker.Bootstrapper
{
    public class Bootstrapper : BootstrapperBase
    {

        private SimpleContainer container;

        public Bootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {
            container = new SimpleContainer();

            //Singleton Instance Registration
            container.Singleton<IWindowManager, WindowManager>();
            container.Singleton<IMainWindowViewModel, MainWindowViewModel>();

            //Provider Registration
            container.PerRequest<IDataInterfaceProvider, DataInterfaceProvider>();
            container.PerRequest<IViewModelProvider, ViewModelProvider>();
            container.PerRequest<IModelProvider, ModelProvider>();
            container.PerRequest<IReportProvider, ReportProvider>();


            //Service Registration
            container.PerRequest<ISerializerService, SerializerService>();

            //ViewModel Registration
            //container.PerRequest<IDaySummaryViewModel, DaySummaryViewModel>();
            //container.PerRequest<IPlannerViewModel, PlannerViewModel>();
            //container.PerRequest<IEditAppSettingsViewModel, EditAppSettingsViewModel>();

        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        protected override void OnStartup(object sender, StartupEventArgs e)
        {
            DisplayRootViewFor<IMainWindowViewModel>();
        }


        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }
    }
}
