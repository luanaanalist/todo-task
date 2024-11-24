
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Application.ViewModel;

namespace ToDoApp.Application.Services
{
    public interface IItemTaskService
    {
        Task<IEnumerable<ItemTaskVM>> GetAllAsync();
        Task<ItemTaskVM> GetByIdAsync(int id);
        Task AddAsync(ItemTaskVM task);
        Task UpdateAsync(ItemTaskVM task);
        Task DeleteAsync(int id);
    }
}
