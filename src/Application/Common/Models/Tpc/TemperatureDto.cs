using CleanArchitecture.Domain.Entities.Tpc;

namespace CleanArchitecture.Application.Common.Models.Tpc;

public class TemperatureDto:BaseEntity<TemperatureFile>
{
    public int Id { get; set; }
    
    public TemperatureFile File { get; set; }
}
