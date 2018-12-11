using System.Threading.Tasks;
using System.Windows.Controls;

using Caliburn.Micro;

using MaterialDesignThemes.Wpf;

namespace TImesheetTracker.Services
{
    public static class DialogService
    {
        public static async Task<object> ShowDialog(object viewModel)
        {
            UserControl view = ViewLocator.LocateForModel(viewModel, null, null) as UserControl;
            ViewModelBinder.Bind(viewModel, view, null);
            return await DialogHost.Show(view);
        }
    }
}
