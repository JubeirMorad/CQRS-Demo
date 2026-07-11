using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Todos.Commands.UpdateTodo
{
    public class CreateTodoCommandHandler : IRequestHandler<UpdateTodoCommand>
    {
        private readonly IAppDbContext appDbContext;

        public CreateTodoCommandHandler(IAppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }


        public async Task Handle(UpdateTodoCommand request, CancellationToken cancellationToken)
        {
            Todo? todo = await appDbContext.todos
                                            .FindAsync(request.id, cancellationToken);

            if (todo is null)
                throw new Exception("Todo was not found.");

            todo.Title = request.Title;
            todo.Description = request.description;
            todo.Done = request.done;

            await appDbContext.SaveChangesAsync(cancellationToken);

        }
    }
}