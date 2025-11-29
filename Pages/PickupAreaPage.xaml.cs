using System.Collections;
using System.Drawing;
using System.Reflection.Emit;

namespace Waste2Rewards.Pages;

[QueryProperty(nameof(PickupType), "pickupType")]
public partial class PickupAreaPage : ContentPage
{
    private string _pickupType;
    private string _selectedArea;

    private readonly List<string> _areas = new()
    {
        "Kajang",
        "Cyberjaya / Putrajaya",
        "Cheras",
        "Shah Alam",
        "Seri Kembangan / Cheras",
        "Klang"
    };

    public string PickupType
    {
        get => _pickupType;
        set => _pickupType = value;
    }

    public PickupAreaPage()
    {
        InitializeComponent();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        BuildAreaList();
    }

    private void BuildAreaList()
    {
        AreaList.Children.Clear();

        foreach (var area in _areas)
        {
            var frame = new Frame
            {
                BackgroundColor = Colors.White,
                BorderColor = Color.FromArgb("#E0E0E0"),
                CornerRadius = 10,
                Padding = new Thickness(20),
                HasShadow = false
            };

            var stack = new HorizontalStackLayout
            {
                Spacing = 15
            };

            var radioButton = new RadioButton
            {
                GroupName = "Areas",
                Value = area
            };
            radioButton.CheckedChanged += OnAreaSelected;

            var textStack = new VerticalStackLayout
            {
                Spacing = 2,
                VerticalOptions = LayoutOptions.Center
            };

            textStack.Children.Add(new Label
            {
                Text = area,
                FontSize = 16,
                FontAttributes = FontAttributes.Bold,
                TextColor = Color.FromArgb("#323232")
            });

            textStack.Children.Add(new Label
            {
                Text = "15.58 Km",
                FontSize = 12,
                TextColor = Color.FromArgb("#999999")
            });

            stack.Children.Add(radioButton);
            stack.Children.Add(textStack);

            frame.Content = stack;
            AreaList.Children.Add(frame);
        }
    }

    private void OnAreaSelected(object sender, CheckedChangedEventArgs e)
    {
        if (e.Value && sender is RadioButton rb)
        {
            _selectedArea = rb.Value?.ToString();

            // Show address section
            AreaList.IsVisible = false;
            AddressSection.IsVisible = true;
        }
    }

    private async void OnBackClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }

    private async void OnApplyClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(_selectedArea))
        {
            await DisplayAlert("Error", "Please select an area", "OK");
            return;
        }

        if (string.IsNullOrWhiteSpace(AddressEntry.Text))
        {
            await DisplayAlert("Error", "Please enter your exact address", "OK");
            return;
        }

        var navParams = new Dictionary<string, object>
        {
            { "pickupType", _pickupType },
            { "area", _selectedArea },
            { "address", AddressEntry.Text }
        };

        await Shell.Current.GoToAsync("pickup_date", navParams);
    }
}