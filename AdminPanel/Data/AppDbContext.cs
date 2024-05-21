using AdminPanel.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Text.Json;

namespace AdminPanel.Data;

public class AppDbContext : INotifyPropertyChanged
{


    private readonly string fileName;

    public AppDbContext()
    {
        fileName = Path.Combine(Directory.GetCurrentDirectory(), "JsonData", "Driver.json");

        if (File.Exists(fileName))
        {
            var driverJson = File.ReadAllText(fileName);
            Drivers = JsonSerializer.Deserialize<ObservableCollection<Driver>>(driverJson) ?? new ObservableCollection<Driver>();
        }
        else
        {
            Drivers = new ObservableCollection<Driver>();
        }
    }

    private ObservableCollection<Driver> _drivers;
    public ObservableCollection<Driver> Drivers { get => _drivers;  set { _drivers = value; OnPropertyChanged(); } } 

    public Driver? GetDriver(string driverId)
    {
        return Drivers.FirstOrDefault(p => p.Id.ToString() == driverId);
    }

    public void RemoveDriver(string id)
    {
        var driver = Drivers.FirstOrDefault(x => x.Id.ToString() == id);
        if (driver is not null)
            Drivers.Remove(driver);
        SaveChanges();
    }

    public void UpdateDriver(Driver driver)
    {
        RemoveDriver(driver.Id.ToString());
        Drivers.Add(driver);
        SaveChanges();
    }
    public void SaveChanges()
    {
        try
        {
            var driverJson = JsonSerializer.Serialize(Drivers);
            File.WriteAllText(fileName, driverJson);
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }


    //-------------------------------------------------------------
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? paramName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(paramName));
    //-------------------------------------------------------------
}

