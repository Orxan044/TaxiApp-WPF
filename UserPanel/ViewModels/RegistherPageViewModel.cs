using UserPanel.Command;
using UserPanel.Data;
using UserPanel.Services.Navigation;
using UserPanel.Views;

namespace UserPanel.ViewModels;

public class RegistherPageViewModel : ViewModel
{

    public RelayCommand SignInCommand { get; set; }
    public AppDbContext DbContext { get; set; }

    private readonly INavigationService NavigationService;
    public RegistherPageViewModel(AppDbContext appDbContext, INavigationService navigationService)
    {
        DbContext = appDbContext;
        NavigationService = navigationService;
        SignInCommand = new RelayCommand(SigInClick);

    }

    private void SigInClick(object? obj)
    {
        NavigationService.Navigate<LoginPage, LoginPageViewModel>();
    }
}
