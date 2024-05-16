using AdminPanel.Command;
using AdminPanel.Data;
using AdminPanel.Models;
using System.Windows.Media.Imaging;

namespace AdminPanel.ViewModels;

public class AddDriverViewModel : ViewModel
{
    public AppDbContext DbContext { get; set; }
    public Driver NewDriver { get; set; }

    public RelayCommand AddDriverCommand {  get; set; }
    public RelayCommand ChangeImageCommand { get; set; }
    public AddDriverViewModel(AppDbContext dbContext)
    {
        DbContext = dbContext;
        NewDriver = new()
        {
            DriverCar = new Car()
        };
        AddDriverCommand = new RelayCommand(AddDriver);
        ChangeImageCommand = new RelayCommand(ChangeImage);
    }

    private void ChangeImage(object? obj)
    {
        Microsoft.Win32.OpenFileDialog openFileDialog = new();
        openFileDialog.Filter = "Image files (*.png;*.jpg)|*.png;*.jpg";
        openFileDialog.FilterIndex = 2;
        if (openFileDialog.ShowDialog() == true)
        {
            NewDriver.Image = $"pack://application:,,,/{new(openFileDialog.FileName)}";
            //"pack://application:,,,/AdminPanel;component/Icons/Driver.png"

            //Models.Image image = new(openFileDialog.FileName);
            //Images.Add(image);
            //Photos.Items.Add(new BitmapImage(new Uri(image.ImagePath)));
        }
    }

    private void AddDriver(object? obj)
    {
        DbContext.Drivers.Add(NewDriver);
    }
}
