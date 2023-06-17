namespace CleanArchitecture.Domain.Entities;

public class StapIvn9
{
    public int Id { get; set; }
    
    [Column(TypeName="jsonb")]
    public string? File { get; set; }
}