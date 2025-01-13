using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core;

namespace ToDoApp.Infrastructure
{
    public class ToDoReadRepository : IToDoReadRepository
    {
        public async Task<IEnumerable<ToDoItem>> GetAllAsync()
        {
            return await Task.FromResult(MockToDoItemsData.Instance.GetToDoItems);
        }

        public async Task<ToDoItem> GetByIdAsync(Guid id)
        {
            return await Task.FromResult(MockToDoItemsData.Instance.GetToDoItems.FirstOrDefault(t => t.Id == id));
        }

        public async Task<bool> ExistsAsync(Guid id)
        {
            return await Task.FromResult(MockToDoItemsData.Instance.GetToDoItems.Any(t => t.Id == id));
        }

        public async Task<IEnumerable<ToDoItem>> GetCompletedTasksAsync()
        {
            return await Task.FromResult(MockToDoItemsData.Instance.GetToDoItems.Where(t => t.IsCompleted));
        }

        public async Task<IEnumerable<ToDoItem>> GetTasksByStatusAsync(bool isCompleted)
        {
            return await Task.FromResult(MockToDoItemsData.Instance.GetToDoItems.Where(t => t.IsCompleted == isCompleted));
        }
    }
}
