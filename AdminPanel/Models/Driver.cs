using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AdminPanel.Models;

public class Driver : Entity , INotifyPropertyChanged
{
    //public string? Image { get; set; } = "pack://application:,,,/AdminPanel;component/Icons/Driver.png";

    private string? image = "pack://application:,,,/AdminPanel;component/Icons/Driver.png";

    public string? Image
    {
        get =>  image; 
        set { image = value; OnPropertyChanged(); }
    }

    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? PhoneNumber { get; set; }
    public Car? DriverCar { get; set; }
    public double? Rating { get; set; } = 5;
    public double? Balance { get; set; } = 0;
    public int? RountCount { get; set; } = 0;
    public bool? Status { get; set; } = true;

    //-------------------------------------------------------------
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? paramName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(paramName));
    //-------------------------------------------------------------

}
