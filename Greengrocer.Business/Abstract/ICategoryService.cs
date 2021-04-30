using Greengrocer.Entity.DTO.Category;
using Greengrocer.Entity.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Greengrocer.Business.Abstract
{
    public interface ICategoryService
    {
        Task<int> AddCategory(CategoryAddDto categoryAdd);
        Task<int> UpdateCategory(int id, CategoryAddDto categoryUpdate);
        Task<List<CategoryListDto>> CategoryList();
        Task<CategoryListDto> CategoryGetById(int id);
        int DeleteCategory(int id);
    }
}
