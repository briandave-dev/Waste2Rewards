using System.Drawing;
using Waste2Rewards.Models;
using Waste2Rewards.Services;

namespace Waste2Rewards.Pages;

[QueryProperty(nameof(PickupId), "pickupId")]
public partial class WasteDetailPage : ContentPage
{
    private readonly IWastePickupService _wastePickupService;
    private string _pickupId;
    private WastePickup _currentPickup;

    public string PickupId
    {
        get => _pickupId;
        set => _pickupId = value;
    }

    public WasteDetailPage(IWastePickupService wastePickupService)
    {
        InitializeComponent();
        _wastePickupService = wastePickupService;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadDetails();
    }

    private async Task LoadDetails()
    {
        _currentPickup = await _wastePickupService.GetById(_pickupId);

        if (_currentPickup == null)
        {
            await DisplayAlert("Error", "Pickup not found", "OK");
            await Shell.Current.GoToAsync("..");
            return;
        }

        // Populate fields
        WasteTypeLabel.Text = _currentPickup.WasteType;
        PickupTypeLabel.Text = FormatPickupType(_currentPickup.PickupType);
        AreaLabel.Text = _currentPickup.Area;
        AddressLabel.Text = _currentPickup.Address;
        FrequencyLabel.Text = FormatFrequency(_currentPickup.Frequency);
        DateLabel.Text = _currentPickup.Date.ToString("MMMM dd, yyyy");
        DescriptionLabel.Text = string.IsNullOrWhiteSpace(_currentPickup.Description)
            ? "No description provided"
            : _currentPickup.Description;
        StatusLabel.Text = _currentPickup.Status.ToUpper();

        // Show cancel button only if status is requested
        CancelButton.IsVisible = _currentPickup.Status == "requested";

        // Update status color
        StatusLabel.TextColor = _currentPickup.Status switch
        {
            "requested" => Color.FromArgb("#FF7200"),
            "cancelled" => Color.FromArgb("#DC3545"),
            "done" => Color.FromArgb("#28A745"),
            _ => Color.FromArgb("#6C757D")
        };
    }

    private string FormatPickupType(string type)
    {
        return type switch
        {
            "normal" => "Normal Pickup",
            "with_cleaning" => "Pickup with Cleaning",
            _ => type
        };
    }

    private string FormatFrequency(string frequency)
    {
        return frequency switch
        {
            "once" => "One-time Pickup",
            "weekly" => "Weekly Pickup",
            "fortnightly" => "Every 3 Months",
            _ => frequency
        };
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void OnCancelClicked(object sender, EventArgs e)
    {
        bool confirm = await DisplayAlert(
            "Confirm Cancellation",
            "Are you sure you want to cancel this pickup request?",
            "Yes, Cancel",
            "No");

        if (confirm)
        {
            await _wastePickupService.Cancel(_pickupId);
            await DisplayAlert("Success", "Pickup request cancelled", "OK");
            await Shell.Current.GoToAsync("..");
        }
    }
}