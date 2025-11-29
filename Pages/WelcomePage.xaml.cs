namespace Waste2Rewards.Pages;

public partial class WelcomePage : ContentPage
{
    public WelcomePage()
    {
        InitializeComponent();
    }

    private async void Continue_Clicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(PhoneEntry.Text))
        {
            await DisplayAlert("Error", "Please enter phone number.", "OK");
            return;
        }

        // Send to OTP page
        await Shell.Current.GoToAsync("otp", new Dictionary<string, object>
        {
            { "Phone", PhoneEntry.Text }
        });
    }
}
