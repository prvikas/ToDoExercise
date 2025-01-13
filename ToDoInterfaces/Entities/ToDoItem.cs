using System.ComponentModel.DataAnnotations;

namespace ToDoApp.Core
{
    public class ToDoItem
    {
        [Required]
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        public bool IsCompleted { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? CompletedDate { get; set; }

        public ToDoItem(string title, string description, bool isCompleted = false, DateTime? createdDate = null, DateTime? completedDate = null)
        {
            Id = Guid.NewGuid();
            Title = title;
            Description = description;
            IsCompleted = isCompleted;
            CreatedDate = createdDate.HasValue ? createdDate.Value : DateTime.Now;
            CompletedDate = IsCompleted && !completedDate.HasValue ? DateTime.Now : completedDate;
        }
        public ToDoItem()
        { }
    }
}
