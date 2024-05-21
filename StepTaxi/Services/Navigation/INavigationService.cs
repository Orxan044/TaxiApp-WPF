using StepTaxi.ViewModels;
using System.Windows.Controls;

namespace StepTaxi.Services.Navigation;

public interface INavigationService
{
    void Navigate<TView, TViewModel>() where TView : Page where TViewModel : ViewModel;

}
