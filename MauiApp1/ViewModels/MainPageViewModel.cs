using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using MauiApp1.Model;
using MauiApp1.Services;
using MauiApp1.Views;
using System.Collections.ObjectModel;
namespace MauiApp1.ViewModels
{
   



    public partial class MainPageViewModel : ObservableObject
    {
        private readonly ApiService _apiService;

        public ObservableCollection<Post> Posts { get; } = new();

        public MainPageViewModel(ApiService apiService)
        {
            _apiService = apiService;
            LoadPosts();
        }

        [ObservableProperty]
        bool isLoading;

        private async void LoadPosts()
        {
            IsLoading = true;
            var posts = await _apiService.GetPostsAsync();
            foreach (var post in posts.Take(10))
            {
                Posts.Add(post);
            }
            IsLoading = false;
        }

        [RelayCommand]
        async Task GoToDetail(Post post)
        {
            await Shell.Current.GoToAsync($"///DetailPage", true, new Dictionary<string, object>
{
    { "Post", post }
});

        }
    }

}
