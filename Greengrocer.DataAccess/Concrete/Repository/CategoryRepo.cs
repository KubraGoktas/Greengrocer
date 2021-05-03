using AppCore.Data.EntityFramework;
using Greengrocer.DataAccess.Abstract;
using Greengrocer.Entity.DTO.Category;
using Greengrocer.Entity.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greengrocer.DataAccess.Concrete.Repository
{
    public class CategoryRepo : EFBaseRepo<Category>, ICategoryRepo
    {
        public CategoryRepo(DbContext dbContext):base(dbContext)
        {

        }

        public async Task<CategoryListDto> CategoryGetById(int id)
        {
            var category = await GetByIdAsync(id);
            var categoryDto = new CategoryListDto()
            {
                Name = category.Name,
                Id = category.Id
            };
            return categoryDto;
        }

        public async Task<List<CategoryListDto>> CategoryList()
        {
            return await GetListQueryable(p =>!p.IsDeleted, p => p.Products)
                .Select(p => new CategoryListDto
                {
                    Name = p.Name,
                    Id=p.Id
                }).ToListAsync();
        }

        public async Task UpdateCategory(int id, CategoryAddDto categoryAdd)
        {
            var currentCategory = await GetByIdAsync(id);
            Update(currentCategory);
            currentCategory.Name = categoryAdd.Name;
            currentCategory.ModifiedDate = DateTime.Now;
        }
    }
}
