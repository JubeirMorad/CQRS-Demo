using Domain.Entities;
using MediatR;

namespace Application.Features.Todos.Queries.GetTodoById
{
    public sealed record GetTodoByIdQuery
    (
        Guid id
    ) : IRequest<Todo>;
}