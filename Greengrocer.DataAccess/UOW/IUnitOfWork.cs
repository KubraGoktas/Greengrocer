using Greengrocer.DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Greengrocer.DataAccess.UOW
{
    public interface IUnitOfWork : IAsyncDisposable
    {
        IProductRepo Products { get; }
        ICategoryRepo Categories { get; }



        int Save();

        Task<int> SaveAsync();

        Task<int> SaveTransactionAsync();
    }
}
