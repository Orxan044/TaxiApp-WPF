using SimpleInjector;
using StepTaxi.Data;
using StepTaxi.Services.Navigation;
using StepTaxi.ViewModels;
using StepTaxi.Views;
using System.Windows;

namespace StepTaxi;


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
        //MainContainer.RegisterSingleton<StepTaxiMainViewModel>();
        MainContainer.RegisterSingleton<LoginViewModel>();
        MainContainer.RegisterSingleton<RegistherViewModel>();
        MainContainer.RegisterSingleton<TaxiAppViewModel>();
    }

    private void AddViews()
    {
        MainContainer.RegisterSingleton<MainView>();
        //MainContainer.RegisterSingleton<StepTaxiMainView>();
        MainContainer.RegisterSingleton<LoginView>();
        MainContainer.RegisterSingleton<RegistherView>();
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