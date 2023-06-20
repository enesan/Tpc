using CleanArchitecture.Application.Common.Models.Tpc;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Entities.Tpc;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface IApplicationDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }
    
 //   DbSet<Card> Cards { get; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken);
}
