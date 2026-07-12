

using Application.Features.Todos.Commands.DeleteTodo;
using FluentValidation;

namespace Application.Features.Todos.Commands.UpdateTodo
{
    public class DeleteTodoCommandValidator : AbstractValidator<DeleteTodoCommand>
    {
        public DeleteTodoCommandValidator()
        {
            RuleFor(c => c.id)
                .NotNull()
                .WithMessage("Id cannot be null.");
        }
    }
}