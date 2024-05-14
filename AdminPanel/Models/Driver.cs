namespace AdminPanel.Models;

public class Driver : Entity
{
    public string? Image { get; set; } = "pack://application:,,,/AdminPanel;component/Icons/Driver.png";
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public Car? DriverCar { get; set; }
    public CarLevel? DriverCarLevel { get; set; }
    public double? Rating { get; set; } = 5;
    public double? Balance { get; set; } = 0;
    public int? RountCount { get; set; } = 0;
    public bool? Status { get; set; } = true;

    

}
