using AppCore.Utility.Mapper;
using Greengrocer.Business.Abstract;
using Greengrocer.DataAccess.UOW;
using Greengrocer.Entity.DTO.Product;
using Greengrocer.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greengrocer.Business.Concrete
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddProduct(ProductAddDto productAdd)
        {
            var product = _mapper.Map<ProductAddDto, Product>(productAdd);
            await _unitOfWork.Products.AddAsync(product);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<List<ProductListDto>> ProductList()
        {
            return await _unitOfWork.Products.ProductList();
        }

        public int DeleteProduct(int id)
        {
            _unitOfWork.Products.Delete(id);
            return _unitOfWork.Save();
        }

        public Task<int> UpdateProduct(int id, ProductAddDto productUpdate)
        {
            _unitOfWork.Products.UpdateProduct(id,productUpdate);
            return  _unitOfWork.SaveAsync();
        }

        public bool ControlCategory(int id)
        {
           var result= _unitOfWork.Categories.GetById(id);
            if (result == null)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
