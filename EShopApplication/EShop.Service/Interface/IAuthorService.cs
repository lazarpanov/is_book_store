using EShop.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Service.Interface
{
    public interface IAuthorService
    {
        List<Author> GetAllProducts();
        Author GetDetailsForProduct(Guid? id);
        void CreateNewProduct(Author p);
        void UpdateExistingProduct(Author p);
        void DeleteProduct(Guid id);
    }
}
