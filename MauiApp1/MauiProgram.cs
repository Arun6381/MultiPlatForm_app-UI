using Microsoft.Extensions.Logging;
using CommunityToolkit.Mvvm;
using MauiApp1.Services;
using MauiApp1.ViewModels;
using MauiApp1.Views;
namespace MauiApp1
{
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
            // Dependency Injection
            builder.Services.AddSingleton<ApiService>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainPageViewModel>();
            builder.Services.AddTransient<DetailPage>();
            builder.Services.AddTransient<NotePage>();
           
            builder.Services.AddTransient<DetailPageViewModel>();
         
            builder.Services.AddTransient<NotesViewModel>();
            builder.Services.AddSingleton<IProductService, SqlProductService>();
            builder.Services.AddSingleton<ProductViewModel>();
            builder.Services.AddSingleton<ProductsPage>();

            return builder.Build();
        }
    }
}
