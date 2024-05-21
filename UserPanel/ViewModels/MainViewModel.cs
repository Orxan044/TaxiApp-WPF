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

    public Page? CurrentPage
    {
        get => currentPage; 
        set { currentPage = value!; OnPropertyChanged(); }
    }

    public MainViewModel(AppDbContext dbContext, INavigationService navigationService)
    {
        DbContext = dbContext;
        NavigationService = navigationService;
        CloseClik = new RelayCommand(CloseWindow);

        //-------------------------------------------------
        currentPage = App.MainContainer.GetInstance<LoginPage>();
        currentPage.DataContext = App.MainContainer.GetInstance<LoginPageViewModel>();
        //-------------------------------------------------
    }

    private void CloseWindow(object? obj)
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
