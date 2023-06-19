namespace CleanArchitecture.Domain.Entities;

public class StapIvn9
{
    public int Id { get; set; }
    
    [Column(TypeName="jsonb")]
    public StapIvn9File File { get; set; }
}

public class StapIvn9File :File {
    
    public Sector Sector { get; set; }
}