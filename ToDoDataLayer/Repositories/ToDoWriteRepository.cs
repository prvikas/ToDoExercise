using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core;

namespace ToDoApp.Infrastructure
{
    public class ToDoWriteRepository : IToDoWriteRepository
    {
      
        public async Task<ToDoItem> AddAsync(ToDoItem entity)
        {
            entity.Id = Guid.NewGuid();
            entity.CreatedDate = DateTime.UtcNow;
            MockToDoItemsData.Instance.AddToDoItem(entity);
            return await Task.FromResult(entity);
        }

        public async Task UpdateAsync(ToDoItem entity)
        {
            var index = MockToDoItemsData.Instance.GetToDoItems.FindIndex(t => t.Id == entity.Id);
            if (index != -1)
            {
                MockToDoItemsData.Instance.GetToDoItems[index] = entity;
            }
            await Task.CompletedTask;
        }

        public async Task DeleteAsync(Guid id)
        {
            var ToDo = MockToDoItemsData.Instance.GetToDoItems.FirstOrDefault(t => t.Id == id);
            if (ToDo != null)
            {
                //MockToDoItemsData.Instance.Remove(ToDo);
            }
            await Task.CompletedTask;
        }

        public async Task UpdateStatusAsync(Guid id, bool isCompleted)
        {
            var ToDo = MockToDoItemsData.Instance.GetToDoItems.FirstOrDefault(t => t.Id == id);
            if (ToDo != null)
            {
                ToDo.IsCompleted = isCompleted;
                ToDo.CompletedDate = isCompleted ? DateTime.UtcNow : null;
            }
            await Task.CompletedTask;
        }
    }
}
