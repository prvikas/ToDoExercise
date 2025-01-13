using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using ToDoApp.Core;

namespace ToDoAzureFunction
{
    public class GetAllToDosQuery : IRequest<IEnumerable<ToDoItemDto>>
    {
    }

    public class GetAllToDosQueryHandler : IRequestHandler<GetAllTodosQuery, IEnumerable<ToDoItemDto>>
    {
        private readonly IToDoReadRepository _toDoReadRepository;

        public GetAllToDosQueryHandler(IToDoReadRepository toDoReadRepository)
        {
            _toDoReadRepository = toDoReadRepository;
        }

        public async Task<IEnumerable<ToDoItemDto>> Handle(GetAllTodosQuery request, CancellationToken cancellationToken)
        {
            var todoItems = await _toDoReadRepository.GetAllAsync();
            return todoItems.Select(item => new ToDoItemDto
            {
                Id = item.Id,
                Title = item.Title,
                Description = item.Description,
                IsCompleted = item.IsCompleted
            });
        }
    }
}
