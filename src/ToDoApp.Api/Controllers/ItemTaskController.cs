
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDoApp.Application.Services;
using ToDoApp.Application.ViewModel;

namespace ToDoApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemTaskController : ControllerBase
    {
        private readonly IItemTaskService _itemTaskService;

        public ItemTaskController(IItemTaskService itemTaskService)
        {
            _itemTaskService = itemTaskService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var tasks = await _itemTaskService.GetAllAsync();
            return Ok(tasks);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var task = await _itemTaskService.GetByIdAsync(id);
            if (task == null) return NotFound();
            return Ok(task);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ItemTaskVM taskDto)
        {
            await _itemTaskService.AddAsync(taskDto);
            return CreatedAtAction(nameof(GetById), new { id = taskDto.Id }, taskDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ItemTaskVM taskDto)
        {
            if (id != taskDto.Id) return BadRequest();
            await _itemTaskService.UpdateAsync(taskDto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _itemTaskService.DeleteAsync(id);
            return NoContent();
        }
    }
}
