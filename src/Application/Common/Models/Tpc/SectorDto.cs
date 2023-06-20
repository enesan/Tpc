using CleanArchitecture.Domain.Entities.Tpc;

namespace CleanArchitecture.Application.Common.Models.Tpc;

public class SectorDto:BaseEntity<SectorFile>
{
    public int Id { get; set; }
    public SectorFile File { get; set; }
}
