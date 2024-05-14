using AdminPanel.Command;
using AdminPanel.Data;
using AdminPanel.Services.Navigation;
using AdminPanel.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace AdminPanel.ViewModels;

public class MainViewModel : ViewModel , INotifyPropertyChanged
{
    public RelayCommand CloseWindow { get; set; }
    public RelayCommand DriversCommand { get; set; }


    private Page currentPage;

    public Page? CurrentPage
    {
        get => currentPage;
        set { currentPage = value!; OnPropertyChanged(); }
    }

    public AppDbContext DbContext { get; set; }

    private readonly INavigationService NavigationService;
    public MainViewModel(AppDbContext dbContext , INavigationService navigationService)
    {
        CloseWindow = new RelayCommand(execute: obj => App.Current.MainWindow.Close());
        DriversCommand = new RelayCommand(execute: obj => NavigationService!.Navigate<DriverPageView, DrivePageViewModel>()); 

        DbContext = dbContext;
        NavigationService = navigationService;
        //-------------------------------------------------
        //currentPage = App.MainContainer.GetInstance<DriverPageView>();
        //currentPage.DataContext = App.MainContainer.GetInstance<DrivePageViewModel>();
        //-------------------------------------------------
    }




    //-------------------------------------------------------------
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? paramName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(paramName));
    //-------------------------------------------------------------
}
