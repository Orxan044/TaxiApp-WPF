using AdminPanel.Command;
using AdminPanel.Data;
using AdminPanel.Models;
using AdminPanel.Services.Navigation;
using AdminPanel.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Media.Imaging;
using ToastNotifications.Lifetime;
using ToastNotifications.Messages;
using ToastNotifications.Position;




namespace AdminPanel.ViewModels;

public class AddDriverViewModel : ViewModel , INotifyPropertyChanged
{
    public AppDbContext DbContext { get; set; }
    private readonly INavigationService NavigationService;
    private Driver newDriver;

    public Driver NewDriver
    {
        get =>  newDriver;
        set { newDriver = value; OnPropertyChanged(); }
    }


    public RelayCommand AddDriverCommand {  get; set; }
    public RelayCommand ChangeImageCommand { get; set; }
    public RelayCommand BackToPageCommand { get; set; }
    public AddDriverViewModel(AppDbContext dbContext, INavigationService navigationService)
    {
        DbContext = dbContext;
        NavigationService = navigationService;
        NewDriver = new()
        {
            DriverCar = new Car()
        };
        AddDriverCommand = new RelayCommand(AddDriver);
        ChangeImageCommand = new RelayCommand(ChangeImage);
        BackToPageCommand = new RelayCommand(BackPage);
    }

    private void BackPage(object? obj)
    {
        NavigationService.Navigate<DriverPageView, DrivePageViewModel>();
        NewDriver = new() { DriverCar = new() };
    }

    private void ChangeImage(object? obj)
    {
        Microsoft.Win32.OpenFileDialog openFileDialog = new();
        openFileDialog.Filter = "Image files (*.png;*.jpg)|*.png;*.jpg";
        openFileDialog.FilterIndex = 2;
        if (openFileDialog.ShowDialog() == true)
        {
            Uri uri = new Uri(openFileDialog.FileName, UriKind.Absolute);
            BitmapImage bitmapImage = new BitmapImage(uri);
            NewDriver.Image = bitmapImage.ToString();
            OnPropertyChanged(nameof(Driver));
        }
    }

    private void AddDriver(object? obj)
    {
        notifier.ShowSuccess("Driver Added Successfully");
        DbContext.Drivers.Add(NewDriver);
        DbContext.SaveChanges();
        NewDriver = new() { DriverCar = new() };
        NavigationService.Navigate<DriverPageView,DrivePageViewModel>();
    }


    //-------------------------------------------------------------
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? paramName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(paramName));
    //-------------------------------------------------------------

    #region Create notifier
    ToastNotifications.Notifier notifier = new ToastNotifications.Notifier(cfg =>
    {
        cfg.PositionProvider = new WindowPositionProvider(
            parentWindow: Application.Current.MainWindow,
            corner: Corner.TopLeft,
            offsetX: 5,
            offsetY: 5);

        cfg.LifetimeSupervisor = new TimeAndCountBasedLifetimeSupervisor(
            notificationLifetime: TimeSpan.FromSeconds(2),
            maximumNotificationCount: MaximumNotificationCount.FromCount(2));

        cfg.Dispatcher = Application.Current.Dispatcher;
    });
    #endregion
}
