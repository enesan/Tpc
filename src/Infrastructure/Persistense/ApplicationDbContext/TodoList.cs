using System;
using System.Collections.Generic;

namespace CleanArchitecture.Infrastructure.Persistense.ApplicationDbContext;

public partial class TodoList
{
    public int Id { get; set; }

    public string? Title { get; set; }

    public DateTime Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public virtual ICollection<TodoItem> TodoItems { get; } = new List<TodoItem>();
}
