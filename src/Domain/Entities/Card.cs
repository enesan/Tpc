using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Entities;

[Table("Cards")]
public class Card
{
    public int Id { get; set; }
    public string Name { get; set; }
    
    public string Test { get; set; }

}