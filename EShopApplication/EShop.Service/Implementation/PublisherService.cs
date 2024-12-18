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
    public class PublisherService : IPublisherService
    {
        private readonly IRepository<Publisher> _productRepository;
        private readonly IRepository<BookInShoppingCart> _productInShoppingCartRepository;
        private readonly IUserRepository _userRepository;

        public PublisherService(IRepository<Publisher> productRepository, IRepository<BookInShoppingCart> productInShoppingCartRepository, IUserRepository userRepository)
        {
            _productRepository = productRepository;
            _productInShoppingCartRepository = productInShoppingCartRepository;
            _userRepository = userRepository;
        }

        public void CreateNewProduct(Publisher p)
        {
            _productRepository.Insert(p);
        }


        public void DeleteProduct(Guid id)
        {
            var product = _productRepository.Get(id);
            _productRepository.Delete(product);
        }

        public List<Publisher> GetAllProducts()
        {
            return _productRepository.GetAll().ToList();
        }

        public Publisher GetDetailsForProduct(Guid? id)
        {
            var product = _productRepository.Get(id);
            return product;
        }

        public void UpdateExistingProduct(Publisher p)
        {
            _productRepository.Update(p);
        }

    }
}
