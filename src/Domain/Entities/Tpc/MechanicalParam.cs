namespace CleanArchitecture.Domain.Entities;

public class MechanicalParam
{
    public int Id { get; set; }
    
    [Column(TypeName="jsonb")]
    public string? File { get; set; }
}