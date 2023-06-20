namespace CleanArchitecture.Domain.Entities.Tpc;

public class Sector
{
    public int Id { get; set; }
    
    [Column(TypeName="jsonb")]
    public SectorFile File { get; set; }
}

public class SectorFile
{
    public int Level { get; set; }
    public int Route { get; set; }
}