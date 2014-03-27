using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Todo_Sync.Core.Models;

namespace Todo_Sync.API.Data.Repositories
{
    public interface ITodoRepository : IDisposable
    {
        Task<Todo> GetAsync(int? todoId);
        Task<IEnumerable<Todo>> GetAllAsync();
        Task<int> AddAsync(Todo todo);
        Task UpdateAsync(Todo todo);
        Task DeleteAsync(int? todoId);
    }
}
