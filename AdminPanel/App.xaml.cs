using System.Windows;
using System.Windows.Navigation;
using AdminPanel.Data;
using AdminPanel.ViewModels;
using AdminPanel.Views;
using SimpleInjector;
using AdminPanel.Services.Navigation;
namespace AdminPanel;

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
        MainContainer.RegisterSingleton<INavigationService, Services.Navigation.NavigationService>();
    }

    private void AddViewModels()
    {
        MainContainer.RegisterSingleton<MainViewModel>();
        MainContainer.RegisterSingleton<DrivePageViewModel>();
        MainContainer.RegisterSingleton<DriveListViewModel>();
        MainContainer.RegisterSingleton<AddDriverViewModel>();
        MainContainer.RegisterSingleton<DriveDetalViewModel>();
    }

    private void AddViews()
    {
        MainContainer.RegisterSingleton<MainView>();
        MainContainer.RegisterSingleton<DriverPageView>();
        MainContainer.RegisterSingleton<DriverListPage>();
        MainContainer.RegisterSingleton<AddDriverView>();
        MainContainer.RegisterSingleton<DriveDetalView>();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
        var mainView = MainContainer.GetInstance<MainView>();
        mainView.DataContext = MainContainer.GetInstance<MainViewModel>();
        mainView.Show();
        base.OnStartup(e);
    }
}
