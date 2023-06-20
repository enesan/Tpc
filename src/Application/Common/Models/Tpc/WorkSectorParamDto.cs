using CleanArchitecture.Domain.Entities.Tpc;

namespace CleanArchitecture.Application.Common.Models.Tpc;

public class WorkSectorParamDto:BaseEntity<WorkSectorParamFile>
{
    public int Id { get; set; }
    
    public WorkSectorParamFile File { get; set; }
}
