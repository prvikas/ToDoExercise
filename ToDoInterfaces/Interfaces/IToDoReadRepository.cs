using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Core
{
    public interface IToDoReadRepository : IReadRepository<ToDoItem>
    {
        Task<IEnumerable<ToDoItem>> GetCompletedTasksAsync();
        Task<IEnumerable<ToDoItem>> GetTasksByStatusAsync(bool isCompleted);
    }
}
