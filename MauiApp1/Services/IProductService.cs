using MauiApp1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MauiApp1.Services
{
    public interface IProductService
    {
        Task<List<Product>> GetProductsAsync(); // ✅ no method body here
    }
}

