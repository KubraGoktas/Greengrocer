using AppCore.Utility.Mapper;
using Greengrocer.Business.Abstract;
using Greengrocer.DataAccess.UOW;
using Greengrocer.Entity.DTO.Category;
using Greengrocer.Entity.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Greengrocer.Business.Concrete
{
    public class CategoryService : ICategoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CategoryService(IUnitOfWork unitOfWork , IMapper mapper )
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<int> AddCategory(CategoryAddDto categoryAdd)
        {
            var category = _mapper.Map<CategoryAddDto, Category>(categoryAdd);
            await _unitOfWork.Categories.AddAsync(category);
            return await _unitOfWork.SaveAsync();
        }

        public async Task<CategoryListDto> CategoryGetById(int id)
        {
             
            return await _unitOfWork.Categories.CategoryGetById(id);
        }

        public async Task<List<CategoryListDto>> CategoryList()
        {
            return await _unitOfWork.Categories.CategoryList();
        }

        public int DeleteCategory(int id)
        {
            _unitOfWork.Categories.Delete(id);
           return _unitOfWork.Save();
        }

        public Task<int> UpdateCategory(int id, CategoryAddDto categoryUpdate)
        {
            _unitOfWork.Categories.UpdateCategory(id, categoryUpdate);
            return _unitOfWork.SaveAsync();
        }

        
    }
}
