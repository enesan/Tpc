namespace CleanArchitecture.Domain.Entities;

public class WorkSectorParam
{
    public int Id { get; set; }
    
    [Column(TypeName="jsonb")]
    public string? File { get; set; }
}