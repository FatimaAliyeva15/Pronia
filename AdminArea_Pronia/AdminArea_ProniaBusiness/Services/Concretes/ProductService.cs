using AdminArea_ProniaBusiness.Services.Abstracts;
using AdminArea_ProniaCore.Models;
using AdminArea_ProniaCore.RepositoryAbstracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminArea_ProniaBusiness.Services.Concretes
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public void AddProduct(Product product)
        {
            _productRepository.Add(product);
            _productRepository.Commit();
        }

        public void DeleteProduct(int id)
        {
            var existProduct = _productRepository.Get(x => x.Id == id);
            _productRepository.Delete(existProduct);
            _productRepository.Commit();
        }

        public List<Product> GetAllProducts(Func<Product, bool>? func = null)
        {
            return _productRepository.GetAll(func);
        }

        public Product GetProduct(Func<Product, bool>? func = null)
        {
            return  GetProduct(func);
        }

        public void UpdateProduct(int id, Product newProduct)
        {
            var existProduct = _productRepository.Get(x => x.Id == id);
            existProduct.Name = newProduct.Name;
            existProduct.Description = newProduct.Description;
            existProduct.Price = newProduct.Price;
        }
    }
}
