using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Todos.Commands.CreateTodo
{
    public class CreateTodoCommandHandler : IRequestHandler<CreateTodoCommand, Guid>
    {
        private readonly IAppDbContext appDbContext;

        public CreateTodoCommandHandler(IAppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }


        public async Task<Guid> Handle(CreateTodoCommand request, CancellationToken cancellationToken)
        {
            Todo todo = new()
            {
                Id = Guid.NewGuid(),
                Title = request.Title,
                Description = request.description,
                Done = false
            };

            appDbContext.todos.Add(todo);
            await appDbContext.SaveChangesAsync(cancellationToken);

            return todo.Id;
        }
    }
}