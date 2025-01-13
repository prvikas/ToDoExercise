using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core;

namespace ToDoAzureFunction
{
    public class GetToDoByIdQuery : IRequest<ToDoItemDto>
    {
        public Guid Id { get; set; }
    }

}
