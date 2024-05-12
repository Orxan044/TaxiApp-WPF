using UserPanel.Command;
using UserPanel.Data;
using UserPanel.Model;
using UserPanel.Services.Navigation;
using UserPanel.Views;

namespace UserPanel.ViewModels;

public class RegistherPageViewModel : ViewModel
{
    public User NewUser {  get; set; } 
    public RelayCommand SignInCommand { get; set; }
    public RelayCommand SignUpCommand { get; set; }
    public AppDbContext DbContext { get; set; }

    private readonly INavigationService NavigationService;
    public RegistherPageViewModel(AppDbContext appDbContext, INavigationService navigationService)
    {
        SignInCommand = new RelayCommand(SigInClick);
        SignUpCommand = new RelayCommand(SignUpClick);
        NewUser = new User();
        DbContext = appDbContext;
        NavigationService = navigationService;
    }


    private void SigInClick(object? obj)
    {
        NavigationService.Navigate<LoginPage, LoginPageViewModel>();
    }
    private void SignUpClick(object? obj)
    {
        DbContext.Users.Add(NewUser);
        DbContext.SaveChanges();
    }
}
