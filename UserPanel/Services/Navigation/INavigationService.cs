using System.Windows.Controls;
using UserPanel.ViewModels;

namespace UserPanel.Services.Navigation;

public interface INavigationService
{
    void Navigate<TView, TViewModel>() where TView : Page where TViewModel : ViewModel;
}
