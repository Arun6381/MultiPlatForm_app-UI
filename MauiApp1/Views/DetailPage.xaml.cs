using Microsoft.Maui.Hosting;
using MauiApp1.ViewModels;
namespace MauiApp1.Views;

public partial class DetailPage : ContentPage
{
    public string Id { get; set; }


    public DetailPage(DetailPageViewModel vm)
    {
        InitializeComponent();
        BindingContext = vm;
    }
   async public void BacktoHomePage(object sender,EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(MainPage));
    }

   
}

