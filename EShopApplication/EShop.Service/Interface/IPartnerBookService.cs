using EShop.Domain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EShop.Service.Interface
{
    public interface IPartnerBookService
    {
        List<PartnerBook> GetAllProducts();
        PartnerBook GetDetailsForProduct(Guid? id);
        void CreateNewProduct(PartnerBook p);
        void UpdateExistingProduct(PartnerBook p);
        void DeleteProduct(Guid id);
    }
}
