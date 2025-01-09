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
    public class PartnerBookService : IPartnerBookService
    {
        private readonly IRepository<PartnerBook> _productRepository;
        private readonly IRepository<BookInShoppingCart> _productInShoppingCartRepository;
        private readonly IUserRepository _userRepository;
        public PartnerBookService(IRepository<PartnerBook> productRepository, IRepository<BookInShoppingCart> productInShoppingCartRepository, IUserRepository userRepository)
        {
            _productRepository = productRepository;
            _productInShoppingCartRepository = productInShoppingCartRepository;
            _userRepository = userRepository;
        }

        public void CreateNewProduct(PartnerBook p)
        {
            _productRepository.Insert(p);
        }

        public void DeleteProduct(Guid id)
        {
            var product = _productRepository.Get(id);
            _productRepository.Delete(product);
        }

        public List<PartnerBook> GetAllProducts()
        {
            return _productRepository.GetAll().ToList();
        }

        public PartnerBook GetDetailsForProduct(Guid? id)
        {
            var product = _productRepository.Get(id);
            return product;
        }

        public void UpdateExistingProduct(PartnerBook p)
        {
            _productRepository.Update(p);
        }


    }
}
