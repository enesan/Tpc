namespace CleanArchitecture.Domain.Entities.Tpc;

public class Controller
{
    public int Id { get; set; }
    
    [Column(TypeName="jsonb")]
    public ControllerFile File { get; set; }
}

public class ControllerFile
{
    public Sector Sector { get; set; }
}