using StepTaxi.Command;
using StepTaxi.Data;
using StepTaxi.Services.Navigation;
using StepTaxi.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace StepTaxi.ViewModels;

public class StepTaxiMainViewModel : ViewModel, INotifyPropertyChanged
{
    public AppDbContext DbContext { get; set; }
    public INavigationService NavigationService;

    private Page currentPage;


    public Page? CurrentPage
    {
        get => currentPage;
        set { currentPage = value!; OnPropertyChanged(); }
    }


    public RelayCommand CloseCommand { get; set; }
    public StepTaxiMainViewModel(AppDbContext dbContext, INavigationService navigationService)
    {
        DbContext = dbContext;
        this.NavigationService = navigationService;
        CloseCommand = new RelayCommand(execute: obj => Application.Current.MainWindow.Close());

        //-------------------------------------------------
        currentPage = App.MainContainer.GetInstance<LoginView>();
        currentPage.DataContext = App.MainContainer.GetInstance<LoginViewModel>();
        //-------------------------------------------------
    }


    //-------------------------------------------------------------
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? paramName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(paramName));
    //-------------------------------------------------------------
}
