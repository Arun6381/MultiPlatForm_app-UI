using Microsoft.Maui.Hosting;
using MauiApp1.ViewModels;
namespace MauiApp1.Views;

public partial class DetailPage : ContentPage
{
	
    public DetailPage(DetailPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
}

