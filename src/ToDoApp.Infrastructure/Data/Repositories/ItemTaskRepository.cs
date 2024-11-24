using System.Threading.Tasks;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Repositories;
using ToDoApp.Infrastructure.Data.Context;

namespace ToDoApp.Infrastructure.Data.Repositories
{
    public class ItemTaskRepository(AppDbContext context) : BaseRepository<ItemTask>(context), IItemTaskRepository
    {
    }
}
