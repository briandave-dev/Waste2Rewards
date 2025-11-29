namespace Waste2Rewards.Pages;

public partial class HomePage : ContentPage
{
    public HomePage()
    {
        InitializeComponent();
    }

    private async void OnRequestWastePickupClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("pickup_type");
    }
}