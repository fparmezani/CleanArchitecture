using CleanArchMVC.Domain.Enitties;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CleanArchMVC.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task<IEnumerable<Category>> GetCategories();
        Task<Category> GetById();
        Task<Category> Create();
        Task<Category> Update();
        Task<Category> Remove();


    }
}
