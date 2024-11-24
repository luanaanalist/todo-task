using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Domain.Entities;

namespace ToDoApp.Domain.Repositories
{
    public interface IItemTaskRepository
    {
        Task<IEnumerable<ItemTask>> GetAllAsync();
        Task<ItemTask> GetByIdAsync(int id);
        Task AddAsync(ItemTask task);
        Task UpdateAsync(ItemTask task);
        Task DeleteAsync(int id);
    }
}
