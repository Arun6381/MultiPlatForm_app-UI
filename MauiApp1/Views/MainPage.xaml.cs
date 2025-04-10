using CommunityToolkit.Mvvm.Input;
using MauiApp1.Model;
using MauiApp1.ViewModels;
namespace MauiApp1.Views;

public partial class MainPage : ContentPage
{
    public MainPage(MainPageViewModel viewModel)
    {
        InitializeComponent(); // This should be recognized
        BindingContext = viewModel;
    }

    private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is Post selectedPost)
        {
            var viewModel = BindingContext as MainPageViewModel;
            viewModel?.GoToDetailCommand.Execute(selectedPost);
        }
    }

    private async void Showmore(object sender, EventArgs e)
    {
        if (BindingContext is MainPageViewModel vm)
        {
            vm.Count += 20;
            await vm.ReloadPosts();
        }
    }
    private async void LearnMore_Clicked(object sender, EventArgs e)
    {
        // Navigate to the specified URL in the system browser.
        await Launcher.Default.OpenAsync("https://aka.ms/maui");
    }

    private async void GoToDetailsPage(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(DetailPage));
    }


}
