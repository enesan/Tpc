namespace CleanArchitecture.Domain.Entities.Tpc;

public class MechanicalParam
{
    public int Id { get; set; }
    
    [Column(TypeName="jsonb")]
    public MechanicalParamFile File { get; set; }
}

public class MechanicalParamFile
{
    public int X { get; set; }
    public int Y { get; set; }
    public int PadParam { get; set; }
    public double PadCapacity { get; set; }
    public List<Pad> Pads { get; set; }
    public MechanicalParamFile()
    {
        Pads = new List<Pad>();
    }
}