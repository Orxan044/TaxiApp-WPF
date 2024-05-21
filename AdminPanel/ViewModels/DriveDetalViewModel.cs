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

public class DriveDetalViewModel : ViewModel , INotifyPropertyChanged
{

    public RelayCommand BackToPageCommand {  get; set; } 
    public RelayCommand ChangeImageCommand { get; set; }
    public RelayCommand UpdatedDriverCommand { get; set; }
    public RelayCommand RemoveDriverCommand { get; set; }
    private Driver driver;

    public Driver? Driver
    {
        get => driver; 
        set { driver = value!; OnPropertyChanged(); }
    }

    public AppDbContext DbContext { get; set; }

    private readonly INavigationService NavigationService;
    public DriveDetalViewModel(AppDbContext appDbContext, INavigationService navigationService)
    {
        DbContext = appDbContext;
        NavigationService = navigationService;
        BackToPageCommand = new RelayCommand(BackToPage);
        ChangeImageCommand = new RelayCommand(ChangeImage);
        UpdatedDriverCommand = new RelayCommand(UptadeDriver);
        RemoveDriverCommand = new RelayCommand(RemoveDriver);
    }

    private void RemoveDriver(object? obj)
    {
        DbContext.RemoveDriver(Driver!.Id.ToString());
        notifier.ShowSuccess("The Driver Has Been Removed Successfully");
        NavigationService.Navigate<DriverPageView, DrivePageViewModel>();
    }

    private void UptadeDriver(object? obj)
    {
        DbContext.UpdateDriver(Driver!);
        notifier.ShowSuccess("Driver Updated Successfully");
        Driver = new() { DriverCar = new() };
        NavigationService.Navigate<DriverPageView, DrivePageViewModel>();
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
            Driver!.Image = bitmapImage.ToString();
        }
    }

    private void BackToPage(object? obj)
    {
        NavigationService.Navigate<DriverPageView, DrivePageViewModel>();       
    }

    //-------------------------------------------------------------------------
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? paramName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(paramName));
    //-------------------------------------------------------------------------



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
