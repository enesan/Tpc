namespace CleanArchitecture.Application.Common.Models;

public abstract class BaseEntity<T>
{
    public int Id { get; set; }
    public T File { get; set; }
}