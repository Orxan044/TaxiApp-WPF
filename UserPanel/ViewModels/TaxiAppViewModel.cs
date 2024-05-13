using UserPanel.Command;
using UserPanel.Data;
using UserPanel.Services.Navigation;

namespace UserPanel.ViewModels;

public class TaxiAppViewModel : ViewModel
{
    public RelayCommand CloseWindow { get; set; }

    public AppDbContext DbContext { get; set; }
    //public INavigationService NavigationService { get; set; }

    public TaxiAppViewModel(AppDbContext dbContext)
    {
        CloseWindow = new RelayCommand(execute: obj => App.Current.MainWindow.Close());
        DbContext = dbContext;
    
    }
}
