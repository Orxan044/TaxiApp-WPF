using StepTaxi.Command;
using StepTaxi.Data;
using StepTaxi.Views;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Controls;
using static System.Net.Mime.MediaTypeNames;

namespace StepTaxi.ViewModels;

public class MainViewModel : ViewModel , INotifyPropertyChanged
{
    public RelayCommand CloseCommand { get; set; }

    public AppDbContext DbContext { get; set; }

    private Page currentPage;

    public Page? CurrentPage
    {
        get => currentPage;
        set { currentPage = value!; OnPropertyChanged(); }
    }
    public MainViewModel(AppDbContext dbContext)
    {
        DbContext = dbContext;
        CloseCommand = new RelayCommand(execute: obj => App.Current.MainWindow.Close());

        //-------------------------------------------------
        currentPage = App.MainContainer.GetInstance<LoginView>();
        currentPage.DataContext = App.MainContainer.GetInstance<LoginViewModel>();
        //-------------------------------------------------
    }

    //-------------------------------------------------------------
    public event PropertyChangedEventHandler? PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string? paramName = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(paramName));
    //-------------------------------------------------------------
}
