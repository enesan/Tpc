using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Entities;

public class ElectronicParam
{
    public int Id { get; set; }
    
    [Column(TypeName="jsonb")]
    public File File { get; set; }
}

public class ElectronicParamFile: File
{
    public int PadId { get; set; }
    public int SampaId { get; set; }
    public int FpgaId { get; set; }
}