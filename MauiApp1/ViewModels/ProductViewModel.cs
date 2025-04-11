using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Model;
using MauiApp1.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.ViewModels
{
    public partial class ProductViewModel : ObservableObject
    {
        private readonly IProductService _productService;

        [ObservableProperty]
        ObservableCollection<Product> products = new();

        public ProductViewModel(IProductService productService)
        {
            _productService = productService;
            LoadProductsCommand = new AsyncRelayCommand(LoadProducts);
        }

        public IAsyncRelayCommand LoadProductsCommand { get; }

        private async Task LoadProducts()
        {
            var items = await _productService.GetProductsAsync();
            Products = new ObservableCollection<Product>(items);
        }



    }
}
