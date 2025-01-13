using MediatR;
using ToDoApp.Core;

namespace ToDoAPI
{
    public class UpdateToDoStatusCommand : IRequest<bool>
    {
        public Guid Id { get; set; }
        public bool IsCompleted { get; set; }
    }
}
