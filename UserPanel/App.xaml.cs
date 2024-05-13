using System.Windows;
using UserPanel.Data;
using UserPanel.Services.Navigation;
using UserPanel.Views;
using SimpleInjector;
using UserPanel.ViewModels;

namespace UserPanel;

public partial class App : Application
{
    public static Container Container { get; set; } = new();

    public App()
    {
        AddOtherServices();
        AddViews();
        AddViewModels();
    }

    private void AddOtherServices()
    {
        Container.RegisterSingleton<AppDbContext>();
        Container.RegisterSingleton<INavigationService, NavigationService>();
    }

    private void AddViewModels()
    {
        Container.RegisterSingleton<MainViewModel>();
        Container.RegisterSingleton<LoginPageViewModel>();
        Container.RegisterSingleton<RegistherPageViewModel>();
        Container.RegisterSingleton<TaxiAppViewModel>();
    }

    private void AddViews()
    {
        Container.RegisterSingleton<MainView>();
        Container.RegisterSingleton<LoginPage>();
        Container.RegisterSingleton<RegistherPage>();
        Container.RegisterSingleton<TaxiAppView>();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var mainView = Container.GetInstance<MainView>();
        mainView.DataContext = Container.GetInstance<MainViewModel>();
        mainView.Show();
        base.OnStartup(e);
    }
}
