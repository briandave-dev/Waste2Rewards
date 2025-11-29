namespace Waste2Rewards.Pages;

public partial class PickupTypePage : ContentPage
{
    public PickupTypePage()
    {
        InitializeComponent();
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void OnNormalPickupTapped(object sender, EventArgs e)
    {
        var navParams = new Dictionary<string, object>
        {
            { "pickupType", "normal" }
        };
        await Shell.Current.GoToAsync("pickup_area", navParams);
    }

    private async void OnSchedulePickupTapped(object sender, EventArgs e)
    {
        var navParams = new Dictionary<string, object>
        {
            { "pickupType", "with_cleaning" }
        };
        await Shell.Current.GoToAsync("pickup_area", navParams);
    }
}