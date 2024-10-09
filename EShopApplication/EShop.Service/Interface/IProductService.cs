using EShop.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Service.Interface
{
    public interface IProductService
    {
        List<Book> GetAllProducts();
        Book GetDetailsForProduct(Guid? id);
        void CreateNewProduct(Book p);
        void UpdateExistingProduct(Book p);
        void DeleteProduct(Guid id);
    }
}
