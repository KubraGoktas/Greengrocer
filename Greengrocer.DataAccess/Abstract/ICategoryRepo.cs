using AppCore.Data;
using Greengrocer.Entity.DTO.Category;
using Greengrocer.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greengrocer.DataAccess.Abstract
{
    public interface ICategoryRepo : IBaseRepo<Category>
    {
        Task UpdateCategory(int id, CategoryAddDto categoryAdd);
        Task<List<CategoryListDto>> CategoryList();
        Task<CategoryListDto> CategoryGetById(int id);

    }
}
