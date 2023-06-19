using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Entities;

public class Controller
{
    public int Id { get; set; }
    
    [Column(TypeName="jsonb")]
    public ControllerFile File { get; set; }
}

public class ControllerFile: File
{
    public Sector Sector { get; set; }
}