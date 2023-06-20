using CleanArchitecture.Domain.Entities.Tpc;

namespace CleanArchitecture.Application.Common.Models.Tpc;

public class ElectronicParamDto:BaseEntity<ElectronicParamFile>
{
    public int Id { get; set; }
    public ElectronicParamFile File { get; set; }
}
