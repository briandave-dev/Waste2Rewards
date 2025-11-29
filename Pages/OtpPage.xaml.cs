namespace Waste2Rewards.Pages;

[QueryProperty(nameof(Phone), "Phone")]
public partial class OtpPage : ContentPage
{
    public string Phone { get; set; }

    const string AuthCode = "123456";

    public OtpPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        PhoneText.Text = $"We sent a code to: {Phone}";
    }

    private async void Verify_Clicked(object sender, EventArgs e)
    {
        if (OtpEntry.Text == AuthCode)
        {
            await Shell.Current.GoToAsync("//home");
        }
        else
        {
            await DisplayAlert("Error", "Invalid code.", "OK");
        }
    }
}
