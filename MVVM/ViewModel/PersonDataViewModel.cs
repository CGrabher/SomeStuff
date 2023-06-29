using System.Windows;

namespace MVVM.ViewModel;
public class PersonDataViewModel : BaseViewModel
{
    public PersonDataViewModel()
    {
        SaveCommand = new RelayCommand(ExecuteSave, CanExecuteSave);
    }

    private string? _firstName;
    public string? FirstName
    {
        get => _firstName;
        set
        {
            if (_firstName == value) 
                return;
            _firstName = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(Fullname));
        }
    }

    private string? _lastName;
    public string? LastName
    {
        get => _lastName;
        set
        {
            if (_lastName == value)
                return;
            _lastName = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(Fullname));

        }
    }

    public string Fullname => $"{FirstName} {LastName}";


    public RelayCommand SaveCommand { get; }
    private void ExecuteSave(object? _)
    {
        MessageBox.Show($"Saved: {Fullname}");
        FirstName = null;
        LastName = null;
    }
    private bool CanExecuteSave(object? _)
    {
        return !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName);
    }


  
}
