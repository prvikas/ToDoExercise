using MediatR;
using ToDoApp.Core;

namespace ToDoAPI
{ 
    public class CreateToDoCommand : IRequest<ToDoItemDto>
    {
        public string Title { get; set; }
        public string? Description { get; set; }
    }
}
