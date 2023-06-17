namespace CleanArchitecture.Domain.Entities;

public class Sector
{
    public int Id { get; set; }
    
    [Column(TypeName="jsonb")]
    public string? File { get; set; }
}