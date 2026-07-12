using Application.Common.Exceptions;
using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Todos.Queries.GetTodoById
{
    public class GetTodosQueryHandler : IRequestHandler<GetTodoByIdQuery, Todo>
    {
        private readonly IAppDbContext appDbContext;

        public GetTodosQueryHandler(IAppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<Todo> Handle(GetTodoByIdQuery request, CancellationToken cancellationToken)
        {
            Todo? todo = await appDbContext.todos.FindAsync(request.id, cancellationToken);

            if (todo is null)
                throw new NotFoundException(nameof(Todo), request.id);

            return todo;
        }
    }
}