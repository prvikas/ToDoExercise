using MediatR;
using ToDoApp.Core;
using ToDoApp.Infrastructure;

namespace ToDoAPI.Handlers
{
    public class UpdateToDoStatusCommandHandler : IRequestHandler<UpdateToDoStatusCommand, bool>
    {
        private readonly IToDoWriteRepository _writeRepository;
        private readonly IToDoReadRepository _readRepository;

        public UpdateToDoStatusCommandHandler(
            IToDoWriteRepository writeRepository,
            IToDoReadRepository readRepository)
        {
            _writeRepository = writeRepository;
            _readRepository = readRepository;
        }

        public async Task<bool> Handle(UpdateToDoStatusCommand request, CancellationToken cancellationToken)
        {
            if (!await _readRepository.ExistsAsync(request.Id))
            {
                throw new KeyNotFoundException($"ToDo item with ID {request.Id} not found.");
            }

            await _writeRepository.UpdateStatusAsync(request.Id, request.IsCompleted);
            return true;
        }
    }
}
