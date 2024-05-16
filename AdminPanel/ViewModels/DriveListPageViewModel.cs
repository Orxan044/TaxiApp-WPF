using AdminPanel.Command;
using AdminPanel.Data;
using AdminPanel.Services.Navigation;
using AdminPanel.Views;

namespace AdminPanel.ViewModels;

public class DriveListViewModel : ViewModel
{
    public RelayCommand ShowCommand { get; set; }
    public AppDbContext DbContext { get; set; }
    private readonly INavigationService NavigationService;

    public DriveListViewModel(AppDbContext appDbContext , INavigationService navigationService)
    {
        DbContext = appDbContext;
        NavigationService = navigationService;
        ShowCommand = new RelayCommand(ShowDriver);
    }

    private void ShowDriver(object? id)
    {
        if (id is not null)
        {
            var Driver = DbContext.GetDriver(id.ToString()!);
            if (Driver is not null)
            {
                NavigationService.Navigate<DriveDetalView, DriveDetalViewModel>();
                var MainVm = App.Current.MainWindow.DataContext as MainViewModel;
                if(MainVm is not null)
                {
                    var NewVm = MainVm.CurrentPage!.DataContext as DriveDetalViewModel;
                    NewVm!.Driver = Driver;
                }
            }
        }
    }
}
