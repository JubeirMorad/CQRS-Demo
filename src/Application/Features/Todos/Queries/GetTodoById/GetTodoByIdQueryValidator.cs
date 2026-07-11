
using FluentValidation;

namespace Application.Features.Todos.Queries.GetTodoById
{
    public class GetTodoByIdQueryValidator : AbstractValidator<GetTodoByIdQuery>
    {
        public GetTodoByIdQueryValidator()
        {
            RuleFor(q => q.id)
                .NotNull()
                .WithMessage("Id is required.");
        }
    }
}