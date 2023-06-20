namespace CleanArchitecture.Domain.Entities.Tpc;

public class Pad
{
    public int Id { get; set; }
    
    [Column(TypeName="jsonb")]
    public PadFile File { get; set; }
}

public class PadFile
{
    public int LineNumber { get; set; }
    public int NumberAtLine { get; set; }
    public List<Sector> Sectors { get; set; }

    public PadFile()
    {
        Sectors = new List<Sector>();
    }
}