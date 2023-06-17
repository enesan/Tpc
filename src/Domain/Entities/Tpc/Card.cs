using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Entities;

[Table("Cards")]
public class Card
{
    public int Id { get; set; }
    
    [Column(TypeName="jsonb")]
    public File File { get; set; }


    public Card()
    {
        Id = (new Random()).Next();
    }
    
}

public class CardFile: File
{
    public int[] SampaId { get; set; }
    public int[] FpgaId { get; set; }
    public int SectorId { get; set; }
}