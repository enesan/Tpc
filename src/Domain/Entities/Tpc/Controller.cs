using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Entities;

public class Controller
{
    public int Id { get; set; }
    
    [Column(TypeName="jsonb")]
    public File File { get; set; }
}

public class ControllerFile: File
{
    public int SectorId { get; set; }
}