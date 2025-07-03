using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BackTaskWeb.Data;
using BackTaskWeb.Models;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BackTaskWeb.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskBController : ControllerBase
    {
        private readonly AppDbContext _context;

        //Constructor
        public TaskBController(AppDbContext context)
        {

            _context = context;
        }


        //Optener la Tareas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TaskModel>>> GetTasks()
        {

            return await _context.TaskM.ToListAsync();

        }

        //Optener los estados pendientes
        [HttpGet("Pendiente")]
        public async Task<ActionResult<IEnumerable<TaskModel>>> GetPendientes()
        {
            var pendientes = await _context.TaskM
                .Where(t => t.State == "Pendiente").ToListAsync();

            return pendientes;

        }

        // optener los estados completos
        [HttpGet("Completado")]
        public async Task<ActionResult<IEnumerable<TaskModel>>> GetCompletados()
        {
            var pendientes = await _context.TaskM
                .Where(t => t.State == "Completado").ToListAsync();

            return pendientes;

        }



        //Optener una sola tarea
    
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskModel>> GetTask(int id)
        {
            var task = await _context.TaskM.FindAsync(id);

            if (task == null)
            {

                return NotFound();
            }

            return task;
        }

        // Para crear nueva tareas 
        [HttpPost]
        public async Task<ActionResult<TaskModel>> PostTask(TaskModel taskModel)
        {
            _context.TaskM.Add(taskModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetTask), new { id = taskModel.Id }, taskModel);
        }


        // Actualizar los componentes
        [HttpPut("{id}")]
        public async Task<ActionResult> ACTask(int id, TaskModel taskModel)
        {
            if (id != taskModel.Id)
            {
                return BadRequest();
            }

            _context.Entry(taskModel).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }


         //Borrar tareas
        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteTask(int id)
        {
            {
                var task = await _context.TaskM.FirstOrDefaultAsync(t => t.Id == id);
                if (task == null)
                {
                    return NotFound();
                }

                _context.TaskM.Remove(task);
                await _context.SaveChangesAsync();

                return NoContent();
            }
        }
    }
}
