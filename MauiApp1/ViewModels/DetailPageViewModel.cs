using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using CommunityToolkit.Mvvm.ComponentModel;
using MauiApp1.Model;
namespace MauiApp1.ViewModels
{



    [QueryProperty(nameof(SelectedPost), "Post")]
    public partial class DetailPageViewModel : ObservableObject
    {
        [ObservableProperty]
        Post selectedPost;
    }

}
