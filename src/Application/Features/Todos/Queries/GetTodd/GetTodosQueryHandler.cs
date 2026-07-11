using Application.Common.Interfaces;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Todos.Queries.GetTodd
{
    public class GetTodosQueryHandler : IRequestHandler<GetTodosQuery, List<Todo>>
    {
        private readonly IAppDbContext appDbContext;

        public GetTodosQueryHandler(IAppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public async Task<List<Todo>> Handle(GetTodosQuery request, CancellationToken cancellationToken)
        {
            return await appDbContext.todos.ToListAsync(cancellationToken);
        }
    }
}