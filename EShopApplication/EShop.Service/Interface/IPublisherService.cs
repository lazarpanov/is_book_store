using EShop.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Service.Interface
{
    public interface IPublisherService
    {
        List<Publisher> GetAllProducts();
        Publisher GetDetailsForProduct(Guid? id);
        void CreateNewProduct(Publisher p);
        void UpdateExistingProduct(Publisher p);
        void DeleteProduct(Guid id);
    }
}
