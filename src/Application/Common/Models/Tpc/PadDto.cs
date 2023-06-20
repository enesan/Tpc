using CleanArchitecture.Domain.Entities.Tpc;

namespace CleanArchitecture.Application.Common.Models.Tpc;

public class PadDto:BaseEntity<PadFile>
{
    public int Id { get; set; }
    public PadFile File { get; set; }
}
