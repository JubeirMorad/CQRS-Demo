using Domain.Entities;
using MediatR;

namespace Application.Features.Todos.Queries.GetTodd
{
    public sealed record GetTodosQuery : IRequest<List<Todo>>;
}