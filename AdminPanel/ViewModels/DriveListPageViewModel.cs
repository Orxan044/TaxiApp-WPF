using AdminPanel.Data;
using AdminPanel.Services.Navigation;

namespace AdminPanel.ViewModels;

public class DriveListViewModel : ViewModel
{
    public AppDbContext DbContext { get; set; }
    private readonly INavigationService NavigationService;

    public DriveListViewModel(AppDbContext appDbContext , INavigationService navigationService)
    {
        DbContext = appDbContext;
        NavigationService = navigationService;
    }
}
