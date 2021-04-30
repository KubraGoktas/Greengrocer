using Greengrocer.Entity.DTO.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greengrocer.Business.Abstract
{
    public interface IProductService
    {
        Task<int> AddProduct(ProductAddDto productAdd);
        Task<int> UpdateProduct(int id, ProductAddDto productUpdate);
        Task<List<ProductListDto>> ProductList();
        int DeleteProduct(int id);
        bool ControlCategory(int id);
    }
}
