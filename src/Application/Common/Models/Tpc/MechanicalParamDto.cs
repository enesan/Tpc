using CleanArchitecture.Domain.Entities.Tpc;

namespace CleanArchitecture.Application.Common.Models.Tpc;

public class MechanicalParamDto:BaseEntity<MechanicalParamFile>
{
    public int Id { get; set; }
    
    public MechanicalParamFile File { get; set; }
}

