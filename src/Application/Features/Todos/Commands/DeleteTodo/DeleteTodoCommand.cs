

using MediatR;

namespace Application.Features.Todos.Commands.DeleteTodo
{
    public sealed record DeleteTodoCommand 
    (
        Guid id
    ) : IRequest;
}