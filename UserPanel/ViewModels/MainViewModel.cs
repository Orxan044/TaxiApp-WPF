using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using UserPanel.Command;
using UserPanel.Data;
using UserPanel.Services.Navigation;
using UserPanel.Views;

namespace UserPanel.ViewModels;

public class MainViewModel : ViewModel , INotifyPropertyChanged
{
    public RelayCommand CloseClik { get; set; }
    public AppDbContext DbContext { get; set; }

    private readonly INavigationService NavigationService;
    private Page currentPage;

    public Page CurrentPage
    {
        get => currentPage; 
        set { currentPage = value; OnPropertyChanged(); }
    }

    public MainViewModel(AppDbContext dbContext, INavigationService navigationService)
    {
        CloseClik = new RelayCommand(execute: obj => Application.Current.MainWindow.Close());
        DbContext = dbContext;
        NavigationService = navigationService;

        //-------------------------------------------------
        currentPage = App.MainContainer.GetInstance<LoginPage>();
        currentPage.DataContext = App.MainContainer.GetInstance<LoginPageViewModel>();
        //-------------------------------------------------
    }



    //-------------------------------------------------------------
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? paramName = null) 
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(paramName));
    //-------------------------------------------------------------

} 
