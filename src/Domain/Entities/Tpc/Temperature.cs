namespace CleanArchitecture.Domain.Entities;

public class Temperature
{
    public int Id { get; set; }
    
    [Column(TypeName="jsonb")]
    public TemperatureFile File { get; set; }
}

public class TemperatureFile : File {
    public Sector Sector { get; set; }
    private double T1 { get; set; }
    private double T2 { get; set; }
    private double T3 { get; set; }
}