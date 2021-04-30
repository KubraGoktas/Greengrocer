using Greengrocer.DataAccess.Abstract;
using Greengrocer.DataAccess.Concrete.Context;
using Greengrocer.DataAccess.Concrete.Repository;
using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Transactions;

namespace Greengrocer.DataAccess.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly GreenGrocerDbContext _dbContext;
        private ProductRepo _productRepo;
        private CategoryRepo _categoryRepo;


        public IProductRepo Products => _productRepo ??= new ProductRepo(_dbContext);

        public ICategoryRepo Categories => _categoryRepo ??= new CategoryRepo(_dbContext);

        public UnitOfWork(GreenGrocerDbContext DbContext)
        {
            _dbContext = DbContext;
        }

        public async ValueTask DisposeAsync()
        {
            await _dbContext.DisposeAsync();
        }

        public int Save()
        {
          return _dbContext.SaveChanges();
        }

        public Task<int> SaveAsync()
        {
            return _dbContext.SaveChangesAsync();
        }

        public async Task<int> SaveTransactionAsync()
        {
            int result = -1;
            try
            {
                using TransactionScope tScope = new();
                result = await _dbContext.SaveChangesAsync();
                tScope.Complete();
            }
            catch (ValidationException)
            {
                // Todo: Hata yaz. 
            }
            catch (Exception)
            {
                // Todo: Hata yaz. 
            }
            return result;
        }
    }
}
