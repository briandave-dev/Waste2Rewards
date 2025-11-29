namespace Waste2Rewards.Pages;

[QueryProperty(nameof(PickupType), "pickupType")]
[QueryProperty(nameof(Area), "area")]
[QueryProperty(nameof(Address), "address")]
public partial class PickupDatePage : ContentPage
{
    private string _pickupType;
    private string _area;
    private string _address;
    private string _selectedFrequency;

    public string PickupType
    {
        get => _pickupType;
        set => _pickupType = value;
    }

    public string Area
    {
        get => _area;
        set => _area = value;
    }

    public string Address
    {
        get => _address;
        set => _address = value;
    }

    public PickupDatePage()
    {
        InitializeComponent();

        // Set default dates
        WeekDatePicker.Date = DateTime.Today;
        MonthDatePicker.Date = DateTime.Today;
        ThreeMonthDatePicker.Date = DateTime.Today;
    }

    private void OnFrequencySelected(object sender, CheckedChangedEventArgs e)
    {
        if (!e.Value) return;

        var radioButton = sender as RadioButton;
        _selectedFrequency = radioButton?.Value?.ToString();

        // Hide all date sections first
        WeekDateSection.IsVisible = false;
        MonthDateSection.IsVisible = false;
        ThreeMonthDateSection.IsVisible = false;

        // Show relevant date section
        if (radioButton == WeekRadio)
            WeekDateSection.IsVisible = true;
        else if (radioButton == MonthRadio)
            MonthDateSection.IsVisible = true;
        else if (radioButton == ThreeMonthRadio)
            ThreeMonthDateSection.IsVisible = true;
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void OnApplyClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(_selectedFrequency))
        {
            await DisplayAlert("Error", "Please select a frequency", "OK");
            return;
        }

        DateTime selectedDate = DateTime.Today;

        if (WeekRadio.IsChecked)
            selectedDate = WeekDatePicker.Date;
        else if (MonthRadio.IsChecked)
            selectedDate = MonthDatePicker.Date;
        else if (ThreeMonthRadio.IsChecked)
            selectedDate = ThreeMonthDatePicker.Date;

        var navParams = new Dictionary<string, object>
        {
            { "pickupType", _pickupType },
            { "area", _area },
            { "address", _address },
            { "frequency", _selectedFrequency },
            { "date", selectedDate }
        };

        await Shell.Current.GoToAsync("pickup_completion", navParams);
    }
}