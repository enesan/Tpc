namespace CleanArchitecture.Domain.Entities.Tpc;

public class Temperature
{
    public int Id { get; set; }
    
    [Column(TypeName="jsonb")]
    public TemperatureFile File { get; set; }
}

public class TemperatureFile {
    public Sector Sector { get; set; }
    private double T1 { get; set; }
    private double T2 { get; set; }
    private double T3 { get; set; }
}