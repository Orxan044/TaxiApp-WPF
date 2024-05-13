using System.Windows;
using UserPanel.Data;
using UserPanel.Services.Navigation;
using UserPanel.Views;
using SimpleInjector;
using UserPanel.ViewModels;

namespace UserPanel;

public partial class App : Application
{
    public static Container MainContainer { get; set; } = new();

    public App()
    {
        AddOtherServices();
        AddViews();
        AddViewModels();
    }

    private void AddOtherServices()
    {
        MainContainer.RegisterSingleton<AppDbContext>();
        MainContainer.RegisterSingleton<INavigationService, NavigationService>();
    }

    private void AddViewModels()
    {
        MainContainer.RegisterSingleton<MainViewModel>();
        MainContainer.RegisterSingleton<LoginPageViewModel>();
        MainContainer.RegisterSingleton<RegistherPageViewModel>();
        MainContainer.RegisterSingleton<TaxiAppViewModel>();
    }

    private void AddViews()
    {
        MainContainer.RegisterSingleton<MainView>();
        MainContainer.RegisterSingleton<LoginPage>();
        MainContainer.RegisterSingleton<RegistherPage>();
        MainContainer.RegisterSingleton<TaxiAppView>();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var mainView = MainContainer.GetInstance<MainView>();
        mainView.DataContext = MainContainer.GetInstance<MainViewModel>();
        mainView.Show();
        base.OnStartup(e);
    }
}
