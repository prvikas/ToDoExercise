using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Core;

namespace ToDoAzureFunction
{
    public class GetAllTodosQuery : IRequest<IEnumerable<ToDoItemDto>>
    {
    }
}
