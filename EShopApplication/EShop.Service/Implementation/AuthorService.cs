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
    public class AuthorService : IAuthorService
    {
        private readonly IRepository<Author> _productRepository;
        private readonly IRepository<BookInShoppingCart> _productInShoppingCartRepository;
        private readonly IUserRepository _userRepository;

        public AuthorService(IRepository<Author> productRepository, IRepository<BookInShoppingCart> productInShoppingCartRepository, IUserRepository userRepository)
        {
            _productRepository = productRepository;
            _productInShoppingCartRepository = productInShoppingCartRepository;
            _userRepository = userRepository;
        }

        public void CreateNewProduct(Author p)
        {
            _productRepository.Insert(p);
        }


        public void DeleteProduct(Guid id)
        {
            var product = _productRepository.Get(id);
            _productRepository.Delete(product);
        }

        public List<Author> GetAllProducts()
        {
            return _productRepository.GetAll().ToList();
        }

        public Author GetDetailsForProduct(Guid? id)
        {
            var product = _productRepository.Get(id);
            return product;
        }

        public void UpdateExistingProduct(Author p)
        {
            _productRepository.Update(p);
        }

    }
}

