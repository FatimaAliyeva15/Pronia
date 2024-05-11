using AdminArea_ProniaCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminArea_ProniaBusiness.Services.Abstracts
{
    public interface IProductService
    {
        void AddProduct(Product product);
        void DeleteProduct(int id);
        void UpdateProduct(int id, Product newProduct);
        Product GetProduct(Func<Product, bool>? func = null);
        List<Product> GetAllProducts(Func<Product, bool>? func = null);
    }
}
