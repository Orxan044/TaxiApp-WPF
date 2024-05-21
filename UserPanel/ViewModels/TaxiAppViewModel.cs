using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Windows;
using System.Windows.Controls;
using UserPanel.Command;
using UserPanel.Data;
using UserPanel.Services.Navigation;
using UserPanel.Views;

namespace UserPanel.ViewModels;

public class TaxiAppViewModel : ViewModel , INotifyPropertyChanged
{
    public RelayCommand CloseWindow { get; set; }
    public RelayCommand TaxiMenu { get; set; }


    private Page currentPage;

    public Page CurrentPage
    {
        get => currentPage;
        set { currentPage = value; OnPropertyChanged(); }

    }

    private readonly INavigationService NavigationService;
    public AppDbContext DbContext { get; set; }

    public TaxiAppViewModel(AppDbContext dbContext,INavigationService navigationService)
    {
        TaxiMenu = new RelayCommand(TaxiMenuClick);
        DbContext = dbContext;
        NavigationService = new NavigationService();
        CloseWindow = new RelayCommand(CloseClik);


        //-------------------------------------------------
        currentPage = App.MainContainer.GetInstance<UserMapView>();
        currentPage.DataContext = App.MainContainer.GetInstance<UserMapViewModel>();
        //-------------------------------------------------

    }

    private void TaxiMenuClick(object? obj)
    {
        NavigationService.Navigate<UserMapView, UserMapViewModel>();
    }

    private void CloseClik(object? obj)
    {
        App.Current.MainWindow.Close();
        Environment.Exit(0);
    }




    //-------------------------------------------------------------
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? paramName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(paramName));
    //-------------------------------------------------------------
}
