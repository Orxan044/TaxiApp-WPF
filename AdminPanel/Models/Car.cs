using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AdminPanel.Models;

public class Car 
{
    public string? CarModel { get; set; }
    public string? CarColor { get; set; }

    private int? _carYear;
    public int? CarYear
    {
        get => _carYear;
        set
        {
            if (_carYear != value)
            {
                _carYear = value;
                UpdateDriverCarLevel();
            }
        }
    }

public string? CarNumber { get; set; }
    public double? CarGraphic { get; set; }

    public CarLevel? DriverCarLevel { get; set; }

    public void UpdateDriverCarLevel()
    {
        if (CarYear.HasValue)
        {
            if (CarYear.Value >= 2009 && CarYear.Value < 2014) DriverCarLevel = CarLevel.Eco;
            if (CarYear.Value >= 2015 && CarYear.Value < 2020) DriverCarLevel = CarLevel.Comfort;
            if (CarYear.Value >= 2020 && CarYear.Value <= 2024) DriverCarLevel = CarLevel.Business;
        }
        else DriverCarLevel = null;
        
    }


}
