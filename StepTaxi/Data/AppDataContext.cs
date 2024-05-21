using StepTaxi.Model;
using System.Collections.ObjectModel;
using System.IO;
using System.Text.Json;

namespace StepTaxi.Data;

public class AppDbContext
{
    public ObservableCollection<User> Users { get; set; }

    private string? fileName = "Users.json";

    public AppDbContext()
    {
        if (File.Exists(fileName))
        {
            var UserJson = File.ReadAllText(fileName);
            Users = JsonSerializer.Deserialize<ObservableCollection<User>>(UserJson) ?? new();
        }
        else
            Users = new();
    }
    public User? GetUser(string userMail, string userPassword)
    {
        return Users.FirstOrDefault(u => u.Mail == userMail && u.Password == userPassword);
    }

    public void SaveChanges()
    {
        var UserJson = JsonSerializer.Serialize(Users);
        File.WriteAllText(fileName!, UserJson);
    }


}