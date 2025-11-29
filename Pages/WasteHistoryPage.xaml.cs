using System;
using System.Drawing;
using System.Reflection.Emit;
using Waste2Rewards.Services;

namespace Waste2Rewards.Pages;

public partial class WasteHistoryPage : ContentPage
{
    private readonly IWastePickupService _wastePickupService;

    public WasteHistoryPage(IWastePickupService wastePickupService)
    {
        InitializeComponent();
        _wastePickupService = wastePickupService;
    }

    protected override async void OnAppearing()
    {
        base.OnAppearing();
        await LoadHistory();
    }

    private async Task LoadHistory()
    {
        var history = await _wastePickupService.GetHistory("USER001");

        // Update stats
        TotalWasteLabel.Text = history.Count.ToString();
        TotalRewardLabel.Text = history.Count.ToString();

        // Clear and rebuild list
        WasteList.Children.Clear();

        foreach (var pickup in history)
        {
            var frame = new Frame
            {
                BackgroundColor = Colors.White,
                BorderColor = Color.FromArgb("#E0E0E0"),
                CornerRadius = 10,
                Padding = new Thickness(15),
                HasShadow = false
            };

            var grid = new Grid
            {
                ColumnDefinitions = new ColumnDefinitionCollection
                {
                    new ColumnDefinition { Width = new GridLength(50) },
                    new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
                    new ColumnDefinition { Width = new GridLength(50) }
                },
                ColumnSpacing = 15
            };

            // Icon
            var iconFrame = new Frame
            {
                BackgroundColor = Color.FromArgb("#FFF3E0"),
                CornerRadius = 25,
                Padding = 0,
                HasShadow = false,
                HeightRequest = 50,
                WidthRequest = 50,
                VerticalOptions = LayoutOptions.Center
            };

            var iconLabel = new Label
            {
                Text = GetWasteIcon(pickup.WasteType),
                FontSize = 24,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center
            };
            iconFrame.Content = iconLabel;
            grid.Add(iconFrame, 0, 0);

            // Info
            var infoStack = new VerticalStackLayout
            {
                Spacing = 2,
                VerticalOptions = LayoutOptions.Center
            };
            infoStack.Children.Add(new Label
            {
                Text = pickup.WasteType,
                FontSize = 16,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromArgb("#323232")
            });
            infoStack.Children.Add(new Label
            {
                Text = $"{pickup.Area} - {pickup.Status}",
                FontSize = 12,
                TextColor = Color.FromArgb("#999999")
            });
            grid.Add(infoStack, 1, 0);

            // Count badge
            var countFrame = new Frame
            {
                BackgroundColor = Color.FromArgb("#F5F5F5"),
                CornerRadius = 15,
                Padding = new Thickness(12, 8),
                HasShadow = false,
                VerticalOptions = LayoutOptions.Center
            };
            countFrame.Content = new Label
            {
                Text = "02",
                FontSize = 18,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromArgb("#323232")
            };
            grid.Add(countFrame, 2, 0);

            frame.Content = grid;

            // Add tap gesture
            var tapGesture = new TapGestureRecognizer();
            tapGesture.Tapped += async (s, e) => await OnWasteItemTapped(pickup.Id);
            frame.GestureRecognizers.Add(tapGesture);

            WasteList.Children.Add(frame);
        }

        if (history.Count == 0)
        {
            WasteList.Children.Add(new Label
            {
                Text = "No waste pickup requests yet",
                FontSize = 14,
                TextColor = Color.FromArgb("#999999"),
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 40, 0, 0)
            });
        }
    }

    private string GetWasteIcon(string wasteType)
    {
        return wasteType switch
        {
            "Electrical Waste" => "??",
            "Carbon Emission" => "??",
            "Home Waste" => "??",
            "Plastic Waste" => "??",
            "Metal Waste" => "??",
            _ => "???"
        };
    }

    private async Task OnWasteItemTapped(string pickupId)
    {
        var navParams = new Dictionary<string, object>
        {
            { "pickupId", pickupId }
        };
        await Shell.Current.GoToAsync("waste_detail", navParams);
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("//home");
    }
}