namespace CleanArchitecture.Domain.Entities;

public class Temperature
{
    public int Id { get; set; }
    
    [Column(TypeName="jsonb")]
    public string? File { get; set; }
}