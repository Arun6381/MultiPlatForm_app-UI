using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Json;
using MauiApp1.Model;

namespace MAUIApp2.Services
{
    public class ProductService
    {
        private readonly HttpClient _httpClient;

        public ProductService()
        {
            _httpClient = new HttpClient
            {
                BaseAddress = new Uri("https://localhost:7237/api/products") 
            };
        }

        public async Task<List<Product>> GetProductsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Product>>("products");
        }

        public async Task<Product> GetProductAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Product>($"products/{id}");
        }

        public async Task AddProductAsync(Product product)
        {
            await _httpClient.PostAsJsonAsync("products", product);
        }

        public async Task UpdateProductAsync(int id, Product product)
        {
            await _httpClient.PutAsJsonAsync($"products/{id}", product);
        }

        public async Task DeleteProductAsync(int id)
        {
            await _httpClient.DeleteAsync($"products/{id}");
        }
    }
}

