using AdminPanel.ViewModels;
using System.Windows.Controls;

namespace AdminPanel.Services.Navigation;

public interface INavigationService
{
    void Navigate<TView, TViewModel>() where TView : Page where TViewModel : ViewModel;
}
