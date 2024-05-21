using Microsoft.Win32;
using StepTaxi.Command;
using StepTaxi.Data;
using StepTaxi.Model;
using StepTaxi.Services.Navigation;
using StepTaxi.Views;
using System.Windows;

namespace StepTaxi.ViewModels;

public class LoginViewModel : ViewModel
{
    public RelayCommand SignUpCommand { get; set; }
    public RelayCommand SignInCommand { get; set; }
    public Window View = App.Current.MainWindow;
    public User UserLogin { get; set; }

    public AppDbContext DbContext { get; set; }
    private readonly INavigationService navigationService;

    public LoginViewModel(AppDbContext dbContext, INavigationService navigationService)
    {
        DbContext = dbContext;
        this.navigationService = navigationService;

        UserLogin = new();
        SignUpCommand = new RelayCommand(SigUpClick);
        SignInCommand = new RelayCommand(SigInClick);
    }

    private void SigInClick(object? obj)
    {
        if (DbContext.GetUser(UserLogin.Mail!, UserLogin.Password!) is not null)
        {
            MessageBox.Show("Login");
            App.Current.MainWindow.Close();

            App.Current.MainWindow = null;
            App.Current.MainWindow = new TaxiAppView();

            if (App.Current.MainWindow is not null)
            {
                App.Current.MainWindow.DataContext = new TaxiAppViewModel();

                App.Current.MainWindow.Show();
                //App.Current.MainWindow.Close();
                View.Close();
                App.Current.MainWindow.Close();

                Environment.Exit(0);


            }
            //App.Current.MainWindow = new MainView();
            //App.Current.MainWindow.Close();


            //var mainView = App.MainContainer.GetInstance<TaxiAppView>();
            //mainView.Show();
            //mainView.DataContext = App.MainContainer.GetInstance<TaxiAppViewModel>();

        }
        else MessageBox.Show("No Sign");
    }

    private void SigUpClick(object? obj)
    {
        navigationService.Navigate<RegistherView,RegistherViewModel>();
    }
}
