
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Common.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Todo> todos { get; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}