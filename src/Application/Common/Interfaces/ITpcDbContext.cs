using System.Net.Mime;
using CleanArchitecture.Application.Common.Models.Tpc;
using CleanArchitecture.Domain.Entities.Tpc;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Application.Common.Interfaces;

public interface ITpcDbContext
{
    DbSet<Card> Cards { get; }
    DbSet<Controller> Controllers { get; }
    DbSet<ElectronicParam> ElectronicParams { get; }
    DbSet<MechanicalParam> MechanicalParams { get; }
    DbSet<Pad> Pads { get; }
    DbSet<Sector> Sectors { get; }
    DbSet<StapIvn9> StapIvn9s { get; }
    DbSet<Temperature> Temperatures { get; }
    DbSet<WorkSectorParam> WorkSectorParams { get; }
}