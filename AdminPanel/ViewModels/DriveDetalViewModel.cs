using AdminPanel.Data;
using AdminPanel.Models;
using AdminPanel.Services.Navigation;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AdminPanel.ViewModels;

public class DriveDetalViewModel : ViewModel , INotifyPropertyChanged
{
    private Driver driver;

    public Driver? Driver
    {
        get => driver; 
        set { driver = value; OnPropertyChanged(); }
    }

    public AppDbContext DbContext { get; set; }

    private readonly INavigationService NavigationService;
    public DriveDetalViewModel(AppDbContext appDbContext, INavigationService navigationService)
    {
        DbContext = appDbContext;
        NavigationService = navigationService;       
    }

    //-------------------------------------------------------------------------
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? paramName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(paramName));
    //-------------------------------------------------------------------------

}
