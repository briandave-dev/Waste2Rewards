using Waste2Rewards.Pages;

namespace Waste2Rewards;

public partial class AppShell : Shell
{
    public AppShell()
    {
        InitializeComponent();

        // Register routes for navigation
        Routing.RegisterRoute("pickup_type", typeof(PickupTypePage));
        Routing.RegisterRoute("pickup_area", typeof(PickupAreaPage));
        Routing.RegisterRoute("pickup_date", typeof(PickupDatePage));
        Routing.RegisterRoute("pickup_completion", typeof(PickupCompletionPage));
        Routing.RegisterRoute("waste_detail", typeof(WasteDetailPage));
    }
}