using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StepTaxi.Model;

public class User : INotifyPropertyChanged
{
    private string? firistName;

    public string? FirstName
    {
        get => firistName;
        set { firistName = value; OnPropertyChanged(); }
    }

    private string? lastName;

    public string? LastName
    {
        get => lastName;
        set { lastName = value; OnPropertyChanged(); }
    }
    private long? phoneNumber;

    public long? PhoneNumber
    {
        get => phoneNumber;
        set { phoneNumber = value; OnPropertyChanged(); }
    }

    private string? mail;

    public string? Mail
    {
        get => mail;
        set { mail = value; OnPropertyChanged(); }
    }

    private string? password;

    public string? Password
    {
        get => password;
        set { password = value; OnPropertyChanged(); }
    }


    //------------------------------------------------------------
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? paramName = null) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(paramName));
    //------------------------------------------------------------

}
