using System.Windows;
using System.Windows.Controls;
using UserPanel.ViewModels;
using UserPanel.Views;

namespace UserPanel.Services.Navigation;

public class NavigationService : INavigationService
{
    public void Navigate<TView, TViewModel>() where TView : Page where TViewModel : ViewModel 
    {
        var mainVm = App.Current.MainWindow.DataContext as MainViewModel;
        var TaxiVm = App.Current.MainWindow.DataContext as TaxiAppViewModel;
        if (mainVm is not null)
        {
            mainVm!.CurrentPage = App.MainContainer.GetInstance<TView>();
            mainVm.CurrentPage.DataContext = App.MainContainer.GetInstance<TViewModel>();
        }
        else if (TaxiVm is not null) 
        {
            TaxiVm!.CurrentPage = App.MainContainer.GetInstance<TView>();
            TaxiVm.CurrentPage.DataContext = App.MainContainer.GetInstance<TViewModel>();
        }
    }

    //public void NavigateWindow<TView, TViewModelWindow>() where TView : Window where TViewModelWindow : ViewModel
    //{
    //    var mainView = App.MainContainer.GetInstance<TView>();
    //    mainView.DataContext = App.MainContainer.GetInstance<TViewModelWindow>();
    //    mainView.Show();
    //}
}
