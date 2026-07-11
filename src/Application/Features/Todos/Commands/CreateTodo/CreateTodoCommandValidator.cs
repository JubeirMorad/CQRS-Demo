

using FluentValidation;

namespace Application.Features.Todos.Commands.CreateTodo
{
    public class CreateTodoCommandValidator : AbstractValidator<CreateTodoCommand>
    {
        public CreateTodoCommandValidator()
        {
            RuleFor(c => c.Title)
                .NotEmpty()
                .WithMessage("Title cannot be empty.")
                .Length(5, 100);
                
            RuleFor(c => c.description)
                .Length(5, 500);
        }
    }
}