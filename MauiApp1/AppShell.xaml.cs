
using MauiApp1.Views;

namespace MauiApp1
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(MainPage),typeof(MainPage));
            Routing.RegisterRoute(nameof(DetailPage),typeof(DetailPage));
            Routing.RegisterRoute(nameof(NotePage),typeof(NotePage));
     
        }

     
    }
}
