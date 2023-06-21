using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface IApplicationDbContext : IDbContext
{
    DbSet<TodoList> TodoLists { get; }

    DbSet<TodoItem> TodoItems { get; }

    DbSet<AspNetRole> AspNetRoles { get; }

    DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }

    DbSet<AspNetUser> AspNetUsers { get; set; }

    DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }

    DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }

    DbSet<AspNetUserToken> AspNetUserTokens { get; set; }

    DbSet<DeviceCode> DeviceCodes { get; set; }

    DbSet<Key> Keys { get; set; }

    DbSet<PersistedGrant> PersistedGrants { get; set; }
 
}
