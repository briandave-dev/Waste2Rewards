using Waste2Rewards.Models;
using Waste2Rewards.Services;

namespace Waste2Rewards.Pages;

[QueryProperty(nameof(PickupType), "pickupType")]
[QueryProperty(nameof(Area), "area")]
[QueryProperty(nameof(Address), "address")]
[QueryProperty(nameof(Frequency), "frequency")]
[QueryProperty(nameof(Date), "date")]
public partial class PickupCompletionPage : ContentPage
{
    private readonly IWastePickupService _wastePickupService;
    private string _pickupType;
    private string _area;
    private string _address;
    private string _frequency;
    private DateTime _date;
    private string _imagePath;

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

    public string Frequency
    {
        get => _frequency;
        set => _frequency = value;
    }

    public DateTime Date
    {
        get => _date;
        set => _date = value;
    }

    public PickupCompletionPage(IWastePickupService wastePickupService)
    {
        InitializeComponent();
        _wastePickupService = wastePickupService;
    }

    private async void OnSnapPictureTapped(object sender, EventArgs e)
    {
        try
        {
            var photo = await MediaPicker.CapturePhotoAsync();
            if (photo != null)
            {
                _imagePath = photo.FullPath;

                // Show preview
                var stream = await photo.OpenReadAsync();
                PreviewImage.Source = ImageSource.FromStream(() => stream);
                PreviewImage.IsVisible = true;
                CameraIcon.IsVisible = false;
            }
        }
        catch (Exception ex)
        {
            // Mock image path if camera is not available
            _imagePath = "mock_image.jpg";
            await DisplayAlert("Info", "Image capture mocked", "OK");
        }
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void OnSubmitClicked(object sender, EventArgs e)
    {
        if (WasteTypePicker.SelectedIndex < 0)
        {
            await DisplayAlert("Error", "Please select a waste type", "OK");
            return;
        }

        var wastePickup = new WastePickup
        {
            UserId = "USER001",
            PickupType = _pickupType,
            Area = _area,
            Address = _address,
            Frequency = _frequency,
            Date = _date,
            WasteType = WasteTypePicker.SelectedItem.ToString(),
            Description = DescriptionEditor.Text,
            ImagePath = _imagePath ?? "mock_image.jpg"
        };

        await _wastePickupService.Create(wastePickup);

        await DisplayAlert("Success", "Your waste pickup request has been submitted!", "OK");

        // Navigate to history page and clear navigation stack
        await Shell.Current.GoToAsync("//waste_history");
    }
}