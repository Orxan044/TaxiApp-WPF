﻿using AdminPanel.Models;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;

namespace AdminPanel.Data;

public class AppDbContext
{
    public ObservableCollection<Driver> Drivers { get; set; }

    private string? fileName = "Driver.json";

    public AppDbContext()
    {
        if (File.Exists(fileName))
        {
            var DriverJson = File.ReadAllText(fileName);
            Drivers = JsonSerializer.Deserialize<ObservableCollection<Driver>>(DriverJson) ?? new();
        }
        else
            Drivers = new() { new Driver() { Name = "Orxan" , Surname = "Huseynov" } };
    }

    public void SaveChanges()
    {
        var DriverJson = JsonSerializer.Serialize(Drivers);
        File.WriteAllText(fileName!, DriverJson);
    }

    public Driver? GetDriver(string driverId)
    {
        return Drivers.FirstOrDefault(p => p.Id.ToString() == driverId);
    }
}

