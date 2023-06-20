using CleanArchitecture.Domain.Common;
using CleanArchitecture.Domain.Entities.Tpc;

namespace CleanArchitecture.Application.Common.Models.Tpc;

public class ControllerDto:BaseEntity<ControllerFile>
{
    public int Id { get; set; }
    public ControllerFile File { get; set; }
}
