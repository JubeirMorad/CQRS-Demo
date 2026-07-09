using FluentValidation;
using FluentValidation.Results;
using MediatR;

namespace Application.Behaviors
{
    public class ValidationsBehaviors<TRequest, TResponse> (IEnumerable<IValidator<TRequest>> validators) : 
        IPipelineBehavior<TRequest, TResponse>  where TRequest : notnull
    {

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);

                var result = await Task.WhenAll(validators.Select(v => v.ValidateAsync(context, cancellationToken)));

                List<ValidationFailure> failures = result.SelectMany(r => r.Errors).Where(r => r is not null).ToList();

                if (failures.Any())
                    throw new ValidationException(failures);

            }

            return await next(cancellationToken);
        }

        
    }
}