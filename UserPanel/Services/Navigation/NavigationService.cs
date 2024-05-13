using System.Windows.Controls;
using UserPanel.ViewModels;

namespace UserPanel.Services.Navigation;

public class NavigationService : INavigationService
{
    public void Navigate<TView, TViewModel>() where TView : Page where TViewModel : ViewModel
    {
        var mainVm = App.Current.MainWindow.DataContext as MainViewModel;
        if (mainVm is not null)
        {
            mainVm.CurrentPage = (App.MainContainer.GetInstance<TView>())!;
            mainVm.CurrentPage.DataContext = App.MainContainer.GetInstance<TViewModel>();
        }
    }
}
