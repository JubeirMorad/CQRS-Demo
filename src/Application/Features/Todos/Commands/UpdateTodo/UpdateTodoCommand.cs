

using MediatR;

namespace Application.Features.Todos.Commands.UpdateTodo
{
    public sealed record UpdateTodoCommand 
    (
        Guid id,
        string Title,
        string? description,
        bool done

    ) : IRequest;
}