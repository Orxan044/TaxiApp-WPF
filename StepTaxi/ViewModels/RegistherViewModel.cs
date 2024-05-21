using StepTaxi.Command;
using StepTaxi.Data;
using StepTaxi.Model;
using StepTaxi.Services.Navigation;
using StepTaxi.Views;


namespace StepTaxi.ViewModels;

public class RegistherViewModel : ViewModel
{
    public User NewUser { get; set; }
    public RelayCommand SignInCommand { get; set; }
    public RelayCommand SignUpCommand { get; set; }

    public AppDbContext DbContext { get; set; }
    private readonly INavigationService navigationService;

    public RegistherViewModel(AppDbContext dbContext, INavigationService navigationService)
    {
        DbContext = dbContext;
        this.navigationService = navigationService;

        SignInCommand = new RelayCommand(SigInClick);
        SignUpCommand = new RelayCommand(SignUpClick);
        NewUser = new User();
    }

    private void SigInClick(object? obj)
    {
        navigationService.Navigate<LoginView,LoginViewModel>();
    }
    private void SignUpClick(object? obj)
    {
        DbContext.Users.Add(NewUser);
        DbContext.SaveChanges();
    }
}
