using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Entities;

[Table("Cards")]
public class Card
{
    public int Id { get; set; }
    
    [Column(TypeName="jsonb")]
    public string? File { get; set; }

    public Card()
    {
        Id = (new Random()).Next();
    }

}