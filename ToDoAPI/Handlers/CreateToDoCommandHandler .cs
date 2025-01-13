using MediatR;
using ToDoApp.Core;

namespace ToDoAPI.Handlers
{
    public class CreateToDoCommandHandler : IRequestHandler<CreateToDoCommand, ToDoItemDto>
    {
        private readonly IToDoWriteRepository _repository;

        public CreateToDoCommandHandler(IToDoWriteRepository repository)
        {
            _repository = repository;
        }

        public async Task<ToDoItemDto> Handle(CreateToDoCommand request, CancellationToken cancellationToken)
        {
            var ToDo = new ToDoItem
            {
                Title = request.Title,
                Description = request.Description,
                IsCompleted = false
            };

            var result = await _repository.AddAsync(ToDo);
            return new ToDoItemDto
            {
                Id = result.Id,
                Title = result.Title,
                Description = result.Description,
                IsCompleted = result.IsCompleted
            };
        }
    }
}
