using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Entities;

public class ElectronicParam
{
    public int Id { get; set; }
    
    [Column(TypeName="jsonb")]
    public ElectronicParamFile File { get; set; }
}

public class ElectronicParamFile: File
{
    public List<Pad> Pads { get; set; }
    
    [ForeignKey("SampaId")]
    public int SampaId { get; set; }
    
    [ForeignKey("FpgaId")]
    public int FpgaId { get; set; }

    public ElectronicParamFile()
    {
        Pads = new List<Pad>();
    }
}