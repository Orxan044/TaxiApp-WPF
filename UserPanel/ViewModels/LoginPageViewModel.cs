using System.Windows;
using UserPanel.Command;
using UserPanel.Data;
using UserPanel.Model;
using UserPanel.Services.Navigation;
using UserPanel.Views;

namespace UserPanel.ViewModels;

public class LoginPageViewModel : ViewModel
{
    public User UserInput { get; set; }

    public AppDbContext DbContext { get; set; }

    private readonly INavigationService NavigationService;
    public RelayCommand SignUpCommand { get; set; }
    public RelayCommand SignInCommand { get; set; }

    public LoginPageViewModel(AppDbContext appDbContext , INavigationService navigationService)
    {
        UserInput = new();
        SignUpCommand = new RelayCommand(SigUpClick);
        SignInCommand = new RelayCommand(SigInClick);
        DbContext = appDbContext;
        NavigationService = navigationService;
    }

    private void SigInClick(object? obj)
    {
        if (DbContext.GetUser(UserInput.Mail!, UserInput.Password!) is not null)
        {
            var mainWindow = App.Current.MainWindow;
            var newWindow = new TaxiAppView();
            mainWindow.Close();
            newWindow.Show();
        }
        else MessageBox.Show("No Sign");
    }

    private void SigUpClick(object? obj)
    {
        NavigationService.Navigate<RegistherPage, RegistherPageViewModel>();
    }
}
