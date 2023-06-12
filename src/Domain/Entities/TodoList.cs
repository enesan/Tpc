using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Entities;

[Table("TodoLists")]
public class TodoList : BaseAuditableEntity
{
    public string? Title { get; set; }

    public Colour Colour { get; set; } = Colour.White;

    public IList<TodoItem> Items { get; private set; } = new List<TodoItem>();
}
