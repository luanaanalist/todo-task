
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoApp.Application.Services;
using ToDoApp.Application.ViewModel;
using ToDoApp.Domain.Entities;
using ToDoApp.Domain.Repositories;

namespace ToDoApp.Application.Implementations
{
    public class ItemTaskService : IItemTaskService
    {
        private readonly IItemTaskRepository _repository;
        private readonly IMapper _mapper;

        public ItemTaskService(IItemTaskRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<ItemTaskVM>> GetAllAsync()
        {
            var itensTask = await _repository.GetAllAsync();
            return _mapper.Map<IEnumerable<ItemTaskVM>>(itensTask);
        }

        public async Task<ItemTaskVM> GetByIdAsync(int id)
        {
            var itemTask = await _repository.GetByIdAsync(id);
            return itemTask == null ? null : _mapper.Map<ItemTaskVM>(itemTask);
        }

        public async Task AddAsync(ItemTaskVM taskDto)
        {
            var itemTask = new ItemTask(taskDto.Title, taskDto.Description);
            await _repository.AddAsync(itemTask);
            taskDto.Id = itemTask.Id;
        }

        public async Task UpdateAsync(ItemTaskVM itemTaskaskDto)
        {
            var task = await _repository.GetByIdAsync(itemTaskaskDto.Id);
            if (task == null) return;

            task.SetTitle(itemTaskaskDto.Title);
            task.SetDescription(itemTaskaskDto.Description);

            if (itemTaskaskDto.IsCompleted && !task.IsCompleted)
                task.CompleteTask();

            await _repository.UpdateAsync(task);
        }

        public async Task DeleteAsync(int id)
        {
            await _repository.DeleteAsync(id);
        }
    }
}
