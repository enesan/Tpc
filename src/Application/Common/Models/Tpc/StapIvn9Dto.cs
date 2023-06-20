using CleanArchitecture.Domain.Entities.Tpc;

namespace CleanArchitecture.Application.Common.Models.Tpc;

public class StapIvn9Dto:BaseEntity<StapIvn9File>
{
    public int Id { get; set; }
    
    public StapIvn9File File { get; set; }
}
