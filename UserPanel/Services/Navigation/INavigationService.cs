using System.Windows;
using System.Windows.Controls;
using UserPanel.ViewModels;

namespace UserPanel.Services.Navigation;

public interface INavigationService
{
    void NavigateWindow<TView, TViewModelWindow>() where TView : Window where TViewModelWindow : ViewModel;
    void Navigate<TView, TViewModel>() where TView : Page where TViewModel : ViewModel;

}
