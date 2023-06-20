namespace CleanArchitecture.Domain.Entities.Tpc;

public class ElectronicParam
{
    public int Id { get; set; }
    
    [Column(TypeName="jsonb")]
    public ElectronicParamFile File { get; set; }
}

public class ElectronicParamFile
{
    public List<Pad> Pads { get; set; }
    
   // [ForeignKey("SampaId")]
    public int SampaId { get; set; }
    
   // [ForeignKey("FpgaId")]
    public int FpgaId { get; set; }

    public ElectronicParamFile()
    {
        Pads = new List<Pad>();
    }
}