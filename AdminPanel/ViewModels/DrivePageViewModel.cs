using AdminPanel.Command;
using AdminPanel.Data;
using AdminPanel.Models;
using AdminPanel.Services.Navigation;
using AdminPanel.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;

namespace AdminPanel.ViewModels;

public class DrivePageViewModel : ViewModel, INotifyPropertyChanged
{

    public RelayCommand AddDriverClickCommand { get; set; }

    private Page currentPage;

    public Page? CurrentPage
    {
        get => currentPage;
        set { currentPage = value!; OnPropertyChanged(); }
    }

    public AppDbContext DbContext { get; set; }
    private readonly INavigationService NavigationService;
    public DrivePageViewModel(AppDbContext dbContext,INavigationService navigationService)
    {

        DbContext = dbContext;
        NavigationService = navigationService;
        AddDriverClickCommand = new RelayCommand(AddDriverClick);


        //-------------------------------------------------
        currentPage = App.MainContainer.GetInstance<DriverListPage>();
        currentPage.DataContext = App.MainContainer.GetInstance<DriveListViewModel>();
        //-------------------------------------------------
    }

    private void AddDriverClick(object? obj)
    {
        NavigationService.Navigate<AddDriverView, AddDriverViewModel>();
    }


    //-------------------------------------------------------------
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? paramName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(paramName));
    //-------------------------------------------------------------

}
