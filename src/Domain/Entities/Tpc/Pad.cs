namespace CleanArchitecture.Domain.Entities;

public class Pad
{
    public int Id { get; set; }
    
    [Column(TypeName="jsonb")]
    public string? File { get; set; }
}