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
}
