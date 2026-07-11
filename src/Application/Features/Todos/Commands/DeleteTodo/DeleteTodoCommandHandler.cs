using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;

namespace Application.Features.Todos.Commands.DeleteTodo
{
    public class CreateTodoCommandHandler : IRequestHandler<DeleteTodoCommand>
    {
        private readonly IAppDbContext appDbContext;

        public CreateTodoCommandHandler(IAppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }


        public async Task Handle(DeleteTodoCommand request, CancellationToken cancellationToken)
        {
            Todo? todo = await appDbContext.todos
                                            .FindAsync(request.id, cancellationToken);

            if (todo is null)
                throw new Exception("Todo was not found.");

            appDbContext.todos.Remove(todo);

            await appDbContext.SaveChangesAsync(cancellationToken);

        }
    }
}