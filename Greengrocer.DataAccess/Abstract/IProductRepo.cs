using AppCore.Data;
using Greengrocer.Entity.DTO.Product;
using Greengrocer.Entity.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Greengrocer.DataAccess.Abstract
{
    public interface IProductRepo : IBaseRepo<Product>
    {
        Task UpdateProduct(int id, ProductAddDto productAdd);
        Task<List<ProductListDto>> ProductList();
    }
}
