using AppCore.Data.EntityFramework;
using Greengrocer.DataAccess.Abstract;
using Greengrocer.Entity.DTO.Product;
using Greengrocer.Entity.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Greengrocer.DataAccess.Concrete.Repository
{
    public class ProductRepo : EFBaseRepo<Product>, IProductRepo
    {
        public ProductRepo(DbContext dbContext) : base(dbContext)
        {

        }

        public async Task<List<ProductListDto>> ProductList()
        {
            return await GetListQueryable(p => !p.IsDeleted, p => p.CategoryFK)
                 .Select(p => new ProductListDto
                 {

                     Price = p.Price,
                     Name = p.Name,
                     CategoryId = p.CategoryId,
                     CategoryName = p.CategoryFK.Name

                 }).ToListAsync();
        }

        public async Task UpdateProduct(int id, ProductAddDto productAddDto)
        {
            var currentProduct = await GetByIdAsync(id);
            Update(currentProduct);
            currentProduct.Name = productAddDto.Name;
            currentProduct.Price = productAddDto.Price;
            currentProduct.CategoryId = productAddDto.CategoryId;
            currentProduct.ModifiedDate = DateTime.Now;
        }
    }

}
