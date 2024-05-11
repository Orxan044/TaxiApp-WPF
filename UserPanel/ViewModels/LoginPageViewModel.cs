using UserPanel.Command;
using UserPanel.Data;
using UserPanel.Model;
using UserPanel.Services.Navigation;
using UserPanel.Views;

namespace UserPanel.ViewModels;

public class LoginPageViewModel : ViewModel
{
    public AppDbContext DbContext { get; set; }
    public User NewUser { get; set; } 
    public RelayCommand SignUpCommand { get; set; }

    private readonly INavigationService NavigationService;
    public LoginPageViewModel(AppDbContext appDbContext , INavigationService navigationService)
    {
        SignUpCommand = new RelayCommand(SigUpClick);
        DbContext = appDbContext;
        NavigationService = navigationService;
    }

    private void SigUpClick(object? obj)
    {
        NavigationService.Navigate<RegistherPage, RegistherPageViewModel>();
    }
}
