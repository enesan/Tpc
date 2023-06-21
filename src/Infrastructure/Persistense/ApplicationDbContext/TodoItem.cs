using System;
using System.Collections.Generic;

namespace CleanArchitecture.Infrastructure.Persistense.ApplicationDbContext;

public partial class TodoItem
{
    public int Id { get; set; }

    public int ListId { get; set; }

    public string? Title { get; set; }

    public string? Note { get; set; }

    public int Priority { get; set; }

    public DateTime? Reminder { get; set; }

    public bool Done { get; set; }

    public DateTime Created { get; set; }

    public string? CreatedBy { get; set; }

    public DateTime? LastModified { get; set; }

    public string? LastModifiedBy { get; set; }

    public virtual TodoList List { get; set; } = null!;
}
