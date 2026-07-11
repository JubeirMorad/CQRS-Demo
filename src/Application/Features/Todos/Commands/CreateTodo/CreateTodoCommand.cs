

using MediatR;

namespace Application.Features.Todos.Commands.CreateTodo
{
    public sealed record CreateTodoCommand 
    (
        string Title,
        string? description
    ) : IRequest<Guid>;
}