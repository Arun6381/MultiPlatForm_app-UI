using MauiApp1.ViewModels;

namespace MauiApp1.Views;

public partial class ProductsPage : ContentPage
{
	public ProductsPage(ProductViewModel viewModel)
	{
		InitializeComponent();
        BindingContext = viewModel;
    }
}