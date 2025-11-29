using Microsoft.Extensions.Logging;
using Waste2Rewards.Pages;
using Waste2Rewards.Services;

namespace Waste2Rewards;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        // Register Services
        builder.Services.AddSingleton<IWastePickupService, WastePickupService>();

        // Register Pages
        builder.Services.AddTransient<HomePage>();
        builder.Services.AddTransient<PickupTypePage>();
        builder.Services.AddTransient<PickupAreaPage>();
        builder.Services.AddTransient<PickupDatePage>();
        builder.Services.AddTransient<PickupCompletionPage>();
        builder.Services.AddTransient<WasteHistoryPage>();
        builder.Services.AddTransient<WasteDetailPage>();
        builder.Services.AddTransient<ProfilePage>();

        return builder.Build();
    }
}