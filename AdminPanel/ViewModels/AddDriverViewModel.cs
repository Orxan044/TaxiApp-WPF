using AdminPanel.Command;
using AdminPanel.Data;
using AdminPanel.Models;

namespace AdminPanel.ViewModels;

public class AddDriverViewModel : ViewModel
{
    public AppDbContext DbContext { get; set; }
    public Driver NewDriver { get; set; }

    public RelayCommand AddDriverCommand {  get; set; }

    public AddDriverViewModel(AppDbContext dbContext)
    {
        DbContext = dbContext;
        NewDriver = new()
        {
            DriverCar = new Car()
        };
        AddDriverCommand = new RelayCommand(AddDriver);
    }

    private void AddDriver(object? obj)
    {
        DbContext.Drivers.Add(NewDriver);
    }
}
