using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Todo_Sync.API.DataContext;
using Todo_Sync.Core.Models;

namespace Todo_Sync.API.Data.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly TodoSyncDataContext _context;

        public TodoRepository(TodoSyncDataContext context)
        {
            if (context == null)
            {
                throw new ArgumentNullException("context");
            }

            _context = context;
        }

        public async Task<Todo> GetAsync(int? todoId)
        {
            return await _context.Todos.FindAsync(todoId);
        }

        public async Task<IEnumerable<Todo>> GetAllAsync()
        {
            return await _context.Todos.ToListAsync();
        }

        public async Task<int> AddAsync(Todo todo)
        {
            _context.Todos.Add(todo);
            await _context.SaveChangesAsync();
            return todo.TodoId;
        }

        public async Task UpdateAsync(Todo todo)
        {
            _context.Entry<Todo>(todo)
                .State = EntityState.Modified;

            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int? todoId)
        {
            var todo = await _context.Todos.FindAsync(todoId);
            if (todo != null)
            {
                _context.Todos.Remove(todo);
                await _context.SaveChangesAsync();
            }
        }

        public void Dispose()
        {
            Dispose(true);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context.Dispose();
            }

            GC.SuppressFinalize(this);
        }
    }
}