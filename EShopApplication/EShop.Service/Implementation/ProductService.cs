using EShop.Domain.Domain;
using EShop.Repository.Interface;
using EShop.Service.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Service.Implementation
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Book> _productRepository;
        private readonly IRepository<BookInShoppingCart> _productInShoppingCartRepository;
        private readonly IUserRepository _userRepository;

        public ProductService (IRepository<Book> productRepository, IRepository<BookInShoppingCart> productInShoppingCartRepository, IUserRepository userRepository)
        {
            _productRepository = productRepository;
            _productInShoppingCartRepository = productInShoppingCartRepository;
            _userRepository = userRepository;
        }

        public void CreateNewProduct(Book p)
        {
            _productRepository.Insert(p);
        }

        public void DeleteProduct(Guid id)
        {
            var product = _productRepository.Get(id);
            _productRepository.Delete(product);
        }

        public List<Book> GetAllProducts()
        {
            return _productRepository.GetAll().ToList();
        }

        public Book GetDetailsForProduct(Guid? id)
        {
            var product = _productRepository.Get(id);
            return product;
        }

        public void UpdateExistingProduct(Book p)
        {
            _productRepository.Update(p);
        }
    }
}
