using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Todo.Domain.DTO;
using Todo.Domain.Models;
using Todo.Domain.Repository;

namespace TodoTaskApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodosController(ITaskRepository repository) : ControllerBase
    {

        [HttpGet("GetAllTask")]
        public async Task<IActionResult> GetAllTask()
        {
            var tasks = await repository.GetAllAsync();
            return Ok(tasks);
        }


        [HttpGet("GetTaskBy/{id}")]
        public async Task<IActionResult> GetTaskById(int id)
        {
            var todo = await repository.GetByIdAsync(id);
            if (todo == null)
                return NotFound();

            return Ok(todo);
        }


        [HttpPost("CreateTask")]
        public async Task<IActionResult> Create(CreateTaskDto todo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var created = await repository.CreateAsync(todo);
            return Ok("تسک ایجاد شد");
        }

        [HttpPut("UpdateTask/{id}")]
        public async Task<IActionResult> Update(int id, UpdateTaskDto todo)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var updated = await repository.UpdateAsync(id, todo);
            if (!updated)
                return NotFound();

            return Ok("تسک ویرایش شد");
        }

        [HttpDelete("DeleteBy/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var deleted = await repository.DeleteAsync(id);
            if (!deleted)
                return NotFound();

            return Ok("تسک حذف شد");
        }


    }
}
