namespace CleanArchitecture.Domain.Entities;

public class WorkSectorParam
{
    public int Id { get; set; }
    
    [Column(TypeName="jsonb")]
    public WorkSectorParamFile File { get; set; }
}

public class WorkSectorParamFile
{
    public int Pedestal2 { get; set; }
    public int Qfc { get; set; }
    public int SNoise { get; set; }
    public List<Pad> Pads { get; set; }

    public WorkSectorParamFile()
    {
        Pads = new List<Pad>();
    }
}