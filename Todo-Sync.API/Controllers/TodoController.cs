using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Todo_Sync.API.Data.Repositories;
using Todo_Sync.Core.Models;

namespace Todo_Sync.API.Controllers
{
    public class TodoController : ApiController
    {
        private readonly ITodoRepository _todoRepository = null;

        public TodoController(ITodoRepository todoRepository)
        {
            if (todoRepository == null)
            {
                throw new ArgumentNullException("todoRepository");
            }

            _todoRepository = todoRepository;
        }

        // GET api/Todo
        public async Task<IEnumerable<Todo>> GetTodo()
        {
            return await _todoRepository.GetAllAsync();
        }

        // GET api/Todo/5
        [ResponseType(typeof(Todo))]
        public async Task<IHttpActionResult> GetTodo(int id)
        {
            Todo todo = await _todoRepository.GetAsync(id);
            if (todo == null)
            {
                return NotFound();
            }

            return Ok(todo);
        }

        // PUT api/Todo/5
        public async Task<IHttpActionResult> PutTodo(int id, Todo todo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (todo == null)
            {
                return BadRequest();
            }

            if (id != todo.TodoId)
            {
                return BadRequest();
            }

            await _todoRepository.UpdateAsync(todo);

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST api/Todo
        [ResponseType(typeof(Todo))]
        public async Task<IHttpActionResult> PostTodo(Todo todo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _todoRepository.AddAsync(todo);

            return CreatedAtRoute("DefaultApi", new { id = todo.TodoId }, todo);
        }

        // DELETE api/Todo/5
        [ResponseType(typeof(Todo))]
        public async Task<IHttpActionResult> DeleteTodo(int id)
        {
            Todo todo = await _todoRepository.GetAsync(id);
            if (todo == null)
            {
                return NotFound();
            }

            await _todoRepository.DeleteAsync(id);

            return Ok(todo);
        }

        protected override void Dispose(bool disposing)
        {
            _todoRepository.Dispose();
        }
    }
}
